using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace oag.Core.Models.Digital;

public class Image : Part
{
    [BsonRepresentation(BsonType.String)]
    public string? PageName { get; set; } = null;

    [BsonRepresentation(BsonType.Int32)]
    public int SortIndex { get; set; } = 100;

    [BsonRepresentation(BsonType.Double)]
    public double? AspectRatio { get; set; }

    [BsonRepresentation(BsonType.Int32)]
    public int? ResolutionX { get; set; }

    [BsonRepresentation(BsonType.Int32)]
    public int? ResolutionY { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Fulltext { get; set; }
}