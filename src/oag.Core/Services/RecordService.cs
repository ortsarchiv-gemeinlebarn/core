using oag.Core.Models;
using oag.Core.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using oag.Core.Dto;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace oag.Core.Services;

public class RecordService
{
    private readonly IMongoCollection<Record> recordCollection;
    private readonly DatabaseOptions databaseOptions;

    public RecordService(IOptions<DatabaseOptions> databaseOptions)
    {
        this.databaseOptions = databaseOptions.Value;

        var mongoClient = new MongoClient(this.databaseOptions.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(this.databaseOptions.DatabaseName);

        recordCollection = mongoDatabase.GetCollection<Record>(this.databaseOptions.RecordsCollection);
    }

    public async Task<bool> IsValidUniqueReferenceCode(Record record)
    {
        var records = await this.recordCollection
            .FindAsync(r => r.ParentId == record.ParentId && r.IdentityManagement.ReferenceCode == record.IdentityManagement.ReferenceCode)
            .Result.ToListAsync();

        if (records.Count == 0)
        {
            return true;
        }

        if (records.Count == 1)
        {
            return records.Single().Id == record.Id;
        }

        return false;
    }

    public async Task<RecordDto?> GetAsync(Guid id)
         => await this.recordCollection
            .Aggregate()
            .Match(r => r.Id == id)
            .GraphLookup<Record, string, string, string, Record, IEnumerable<Record>, object>(
                from: this.recordCollection,
                startWith: "$parentId",
                connectFromField: "parentId",
                connectToField: "_id",
                depthField: "depth",
                @as: "parentsHierarchyTemp"
            )
            .AppendStage<object>(@"{
                $addFields: {
                    parentsHierarchy: {
                        $sortArray: {
                            input: {
                                $map:{
                                    input: '$parentsHierarchyTemp',
                                    as: 'item',
                                    in: {
                                        _id: '$$item._id',
                                        parentId: '$$item.parentId',
                                        referenceCode: '$$item.identityManagement.referenceCode',
                                        levelOfDescription: '$$item.identityManagement.levelOfDescription',
                                        title: '$$item.identityManagement.title',
                                        depth: {
                                            $subtract: [ { $subtract: [ { $size: '$parentsHierarchyTemp' }, 1 ] } , '$$item.depth']
                                        }
                                    }
                                }
                            },
                            sortBy: { depth: 1 }
                        }
                    }
                }
            }")
            .AppendStage<object>(@"{
                $addFields: {
                    parentsHierarchyReference: {
                        $reduce: {
                            input: '$parentsHierarchy.referenceCode',
                            initialValue: '',
                            in: {
                                $concat: [
                                    '$$value',
                                    {
                                        $cond: [
                                            { $eq: ['$$value', ''] },
                                            '',
                                            '.'
                                        ]
                                    },
                                    '$$this'
                                ]
                            }
                        }
                    }
                }
            }")
            .AppendStage<RecordDto>(@"{
                $project: {
                    parentsHierarchyTemp: false
                }
            }")
            .FirstOrDefaultAsync();

    public async Task<RecordOrentationDto?> GetOrientationAsync(Guid id)
    {
        return await this.recordCollection
            .Aggregate()
            .Match(r => r.Id == id)
            .GraphLookup<Record, string, string, string, Record, IEnumerable<Record>, object>(
                from: this.recordCollection,
                startWith: "$parentId",
                connectFromField: "parentId",
                connectToField: "_id",
                depthField: "depth",
                @as: "parentsHierarchyTemp"
            )
            .AppendStage<object>(@"{
                $addFields: {
                    parentsHierarchy: {
                        $sortArray: {
                            input: {
                                $map:{
                                    input: '$parentsHierarchyTemp',
                                    as: 'item',
                                    in: {
                                        _id: '$$item._id',
                                        parentId: '$$item.parentId',
                                        referenceCode: '$$item.identityManagement.referenceCode',
                                        levelOfDescription: '$$item.identityManagement.levelOfDescription',
                                        title: '$$item.identityManagement.title',
                                        depth: {
                                            $subtract: [ { $subtract: [ { $size: '$parentsHierarchyTemp' }, 1 ] } , '$$item.depth']
                                        }
                                    }
                                }
                            },
                            sortBy: { depth: 1 }
                        }
                    }
                }
            }")
            .AppendStage<object>(@"{
                $addFields: {
                    parentsHierarchyReference: {
                        $reduce: {
                            input: '$parentsHierarchy.referenceCode',
                            initialValue: '',
                            in: {
                                $concat: [
                                    '$$value',
                                    {
                                        $cond: [
                                            { $eq: ['$$value', ''] },
                                            '',
                                            '.'
                                        ]
                                    },
                                    '$$this'
                                ]
                            }
                        }
                    }
                }
            }")
            .Lookup(
                  foreignCollectionName: this.databaseOptions.RecordsCollection,
                  localField: "_id",
                  foreignField: "parentId",
                  @as: "children"
            )
            .Lookup(
                  foreignCollectionName: this.databaseOptions.RecordsCollection,
                  localField: "parentId",
                  foreignField: "parentId",
                  @as: "siblings"
            )
            .AppendStage<RecordOrentationDto>(@"{
                $project: {
                  parentId: true,
                  referenceCode:'$identityManagement.referenceCode',
                  levelOfDescription: '$identityManagement.levelOfDescription',       
                  title: '$identityManagement.title',
                    parentsHierarchyReference: true,
                    parentsHierarchy: true,
                  siblings: {
                      $map: {
                        input: {
                          $filter: {
                            input: '$siblings',
                            as: 'record',
                            cond: {
                              $ne: ['$$record._id', '$_id'],
                            },
                          },
                        },
                        as: 'item',
                        in: {
                          _id: 
                            '$$item._id',
                          referenceCode:
                            '$$item.identityManagement.referenceCode',
                          levelOfDescription:
                            '$$item.identityManagement.levelOfDescription',
                          title:
                            '$$item.identityManagement.title',
                        },
                      },
                },
                children: {
                      $map: {
                        input: '$children',
                        as: 'item',
                        in: {
                          _id: 
                            '$$item._id',
                          referenceCode:
                            '$$item.identityManagement.referenceCode',
                          levelOfDescription:
                            '$$item.identityManagement.levelOfDescription',
                          title:
                            '$$item.identityManagement.title',
                        },
                      },
                    },
                }
            }")
            .FirstOrDefaultAsync();
    }

    public async Task<RecordDto?> CreateAsync(Record record)
    {
        await this.recordCollection.InsertOneAsync(record);
        return await this.GetAsync(record.Id);
    }

    public async Task<RecordDto?> UpdateAsync(Record record)
    {
        var result = await this.recordCollection.ReplaceOneAsync(r => r.Id == record.Id, record);
        return await this.GetAsync(record.Id);
    }

    public async Task RemoveAsync(Guid id) =>
        await this.recordCollection.DeleteOneAsync(r => r.Id == id);
}