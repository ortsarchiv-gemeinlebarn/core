using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using oag.Core.Attributes;

namespace oag.Core.Models;

public record Record
{
    [BsonId]
    public Guid Id { get; set; }

    public Guid? ParentId { get; set; }

    [IsadMetaDataParent("1", "Identity Statement", "Identifikation")]
    public RecordIdentityManagement IdentityManagement { get; set; } = new RecordIdentityManagement();

    [IsadMetaDataParent("2", "Context", "Kontext")]
    public RecordContext Context { get; set; } = new RecordContext();

    [IsadMetaDataParent("3", "Content and Structure ", "Inhalt und innere Ordnung")]
    public RecordContentAndStructure ContentAndStructure { get; set; } = new RecordContentAndStructure();

    [IsadMetaDataParent("4", "Conditions of access and use", "Zugangs- und Benutzungsbestimmungen")]
    public RecordConditionsOfAccessAndUse ConditionsOfAccessAndUse { get; set; } = new RecordConditionsOfAccessAndUse();

    [IsadMetaDataParent("5", "Allied Materials", "Sachverwandte Unterlagen")]
    public RecordAlliedMaterials AlliedMaterials { get; set; } = new RecordAlliedMaterials();

    [IsadMetaDataParent("6", "Notes", "Anmerkungen")]
    public RecordNotes Notes { get; set; } = new RecordNotes();

    [IsadMetaDataParent("7", "Description Control", "Verzeichnungskontrolle")]
    public RecordDescriptionControl DescriptionControl { get; set; } = new RecordDescriptionControl();
}