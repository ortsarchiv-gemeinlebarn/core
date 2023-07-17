using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using oag.Core.Helper;
using oag.Core.Types;

namespace oag.Core.Obsolete;

public record Record
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = new Guid().ToString();

    [BsonRepresentation(BsonType.ObjectId)]
    public string? ParentId { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? ReferenceCode { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Title { get; set; } = null;

    public Dating Date { get; set; } = new Dating();

    private string _levelOfDescription = IsadLevelsOfDescription.Fonds;

    [BsonRepresentation(BsonType.String)]
    public string LevelOfDescription
    {
        get { return _levelOfDescription; }
        set
        {
            if (!value.IsValidLevelOfDescription())
            {
                throw new ArgumentOutOfRangeException("Non ISAD(G) Level of Description!");
            }

            _levelOfDescription = value;
        }
    }

    [BsonRepresentation(BsonType.String)]
    public string? Extent { get; set; } = null;

    // Provenienzstelle
    [BsonRepresentation(BsonType.String)]
    public string? NameOfCreators { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? BiographicalOrBiographicalHistory { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? ArchivalHistory { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? ImmediateSourceOfAcquisitionOrTransfer { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? ScopeAndContent { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? AppraisalDestructionAndSchedulingInformation { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? Accruals { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? SystemOfArrangement { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? ConditionsGoveringAccess { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? ConditionsGoveringReproduction { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string? LanguageScriptsOfMaterial { get; set; } = "Deutch; Latein";

    [BsonRepresentation(BsonType.String)]
    public string? PhysicalCharacteristicsAndTechnicalReuirements { get; set; }

    // Default per null
    [BsonRepresentation(BsonType.String)]
    public string? FindingAids { get; set; } = null;

    // Relation to Location
    [BsonRepresentation(BsonType.Document)]
    public Location? ExistenceAndLocationOfOriginals { get; set; } = null;

    // Relation to Location
    [BsonRepresentation(BsonType.Document)]
    public Location? ExistenceAndLocationOfCopies { get; set; } = null;

    // Array of ObjectIds
    [BsonRepresentation(BsonType.Array)]
    public List<string> RelatedUnitsOfDescription { get; set; } = new List<string>();

    // Array of Strings (= Bibilographie)
    // TODO: Eigenes Biblographie Model?
    [BsonRepresentation(BsonType.Array)]
    public List<string> PublicationNote { get; set; } = new List<string>();

    [BsonRepresentation(BsonType.String)]
    public string? Note { get; set; } = null;

    [BsonRepresentation(BsonType.String)]
    public string? ArchivistsNote { get; set; } = null;

    // TODO: Relation to Conventions?
    [BsonRepresentation(BsonType.String)]
    public string? RulesOrConventions { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime? DateOfCreate { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime? DateOfModified { get; set; }

    #region Digital

    #endregion
}