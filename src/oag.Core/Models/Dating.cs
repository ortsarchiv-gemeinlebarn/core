using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace oag.Core.Models;

public class Dating
{
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime? FormalPeriodBegin { get; set; } = null;

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime? FormalPeriodEnd { get; set; } = null;

    [BsonRepresentation(BsonType.String)]
    public string? Text { get; set; } = null;

    public override string ToString() => this.Text ?? "Unbekannt";
}