using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using oag.Core.Attributes;


namespace oag.Core.Models;

public class RecordContentAndStructure
{
    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("3.1", "Scope and content", "Form und Inhalt")]
    public string? ScopeAndContent { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("3.2", "Appraisal, destruction and scheduling information", "Bewertung und Skartierung")]
    public string? AppraisalDestructionAndSchedulingInformation { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("3.3", "Accruals", "Neuzugänge")]
    public string? Accruals { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("3.4", "System of arrangement", "Ordnung und Klassifikation")]
    public string? SystemOfArrangement { get; set; }
}
