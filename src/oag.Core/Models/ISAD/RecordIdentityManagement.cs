using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using oag.Core.Attributes;
using oag.Core.Types;
using oag.Core.Helper;

namespace oag.Core.Models;

public class RecordIdentityManagement
{
    [IsadMetaData("1.1", "Reference code(s)", "Signatur")]
    public string? ReferenceCode { get; set; }

    [IsadMetaData("1.2", "Title", "Titel")]
    public string? Title { get; set; } = null;

    [IsadMetaData("1.3", "Date(s)", "Entstehungszeitraum/Laufzeit")]
    public Dating Date { get; set; } = new Dating();

    private string _levelOfDescription = IsadLevelsOfDescription.Fonds;

    [BsonRepresentation(BsonType.String)]
    [IsadMetaData("1.4", "Level of description", "Verzeichnungsstufe")]
    public string LevelOfDescription
    {
        get { return _levelOfDescription; }
        set
        {
            //if (!value.IsValidLevelOfDescription())
            //{
            //    throw new ArgumentOutOfRangeException("Non ISAD(G) Level of Description!");
            //}

            _levelOfDescription = value;
        }
    }

    [IsadMetaData("1.5", "Extent", "Umfang")]
    public string? Extent { get; set; } = null;
}
