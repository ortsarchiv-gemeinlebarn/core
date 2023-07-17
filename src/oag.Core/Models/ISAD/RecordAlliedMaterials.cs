using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using oag.Core.Attributes;

namespace oag.Core.Models;

public class RecordAlliedMaterials
{
    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("5.1", "Existence and location of originals", "Aufbewahrungsort der Originale")]
    public string? ExistenceAndLocationOfOriginals { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("5.2", "Existence and location of copies", "Kopien bzw. Reproduktionen")]
    public string? ExistenceAndLocationOfCopies { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("5.3", "Related units of description", "Verwandte Verzeichnungseinheiten")]
    public string? RelatedUnitsOfDescription { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("5.4", "Publication note", "Veröffentlichungen")]
    public string? PublicationNote { get; set; }
}
