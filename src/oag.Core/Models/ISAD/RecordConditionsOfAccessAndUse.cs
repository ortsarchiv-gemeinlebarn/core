using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using oag.Core.Attributes;


namespace oag.Core.Models;

public class RecordConditionsOfAccessAndUse
{
    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("4.1", "Conditions governing access", "Zugangsbestimmungen")]
    public string? ConditionsGoveringAccess { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("4.2", "Conditions governing reproduction", "Reproduktionsbestimmungen")]
    public string? ConditionsGoveringReproduction { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("4.3", "Language/scripts of material", "Sprache/Schrift")]
    public string? LanguageScriptsOfMaterial { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("4.4", "Physical characteristics and technical requirements", "Physische Beschaffenheit und technische Anforderungen")]
    public string? PhysicalCharacteristicsAndTechnicalReuirements { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("4.5", "Finding aids", "Findmittel")]
    public string? FindingAids { get; set; }
}
