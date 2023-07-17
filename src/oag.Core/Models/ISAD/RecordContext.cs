using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using oag.Core.Attributes;


namespace oag.Core.Models;

public class RecordContext
{
    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("2.1", "Name of creator(s)", "Name der Provenienzstelle(n)")]
    public string? NameOfCreators { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("2.2", "Administrative / Biographical history", "Verwaltungsgeschichte/Biographische Angaben")]
    public string? BiographicalOrBiographicalHistory { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("2.3", "Archival history", "Bestandsgeschichte")]
    public string? ArchivalHistory { get; set; }

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("2.4", "Immediate source of acquisition or transfer", "Abgebende Stelle")]
    public string? ImmediateSourceOfAcquisitionOrTransfer { get; set; }
}
