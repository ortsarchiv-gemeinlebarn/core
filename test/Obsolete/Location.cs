using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace oag.Core.Obsolete;

public record Location
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public bool Internal { get; set; } = true;

    public string? Title { get; set; }

    public string? Notes { get; set; }
}