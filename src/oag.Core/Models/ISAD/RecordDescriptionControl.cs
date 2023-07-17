using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using oag.Core.Attributes;


namespace oag.Core.Models;

public class RecordDescriptionControl
{
    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("7.1", "Archivist's Note", "Informationen des Bearbeiters")]
    public string? ArchivistsNote { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("7.2", "Rules or Conventions", "Verzeichnungsgrundsätze")]
    public string? RulesOrConventions { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("7.3", "Date(s) of descriptions", "Datum oder Zeitraum der Verzeichnung")]
    public DateTime? DateOfDescriptions { get; set; }
}
