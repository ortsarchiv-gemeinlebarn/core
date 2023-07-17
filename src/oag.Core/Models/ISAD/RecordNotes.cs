using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using oag.Core.Attributes;


namespace oag.Core.Models;

public class RecordNotes
{
    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("6.1", "Note", "Allgemeine Anmerkungen")]
    public string? Note { get; set; }
}
