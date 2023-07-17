using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace oag.Core.Models.Digital;

public abstract class DigitalRepresentation
{
    /// <summary>Primary Key</summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    /// <summary>Foreign Key</summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string RecordId { get; set; }

    /// <summary>The Type represents the general Type</summary>
    [BsonRepresentation(BsonType.String)]
    private string type = "image";
    public string Type
    {
        get { return type; }
        set
        {
            ThrowExceptionIfIsImpossibleType(value);
            type = value;
        }
    }

    public string MimeType { get; set; } = "image/tiff";

    /// <summary>Base64 Image</summary>
    [BsonRepresentation(BsonType.String)]
    public string Thumbnail { get; set; } = String.Empty;

    [BsonRepresentation(BsonType.Double)]
    public double? ThumbnailAspectRatio { get; set; }

    /// <summary>Is the digital File originally a digital File or scanned, ...</summary>
    [BsonRepresentation(BsonType.Boolean)]
    public bool GenuineDigital { get; set; }

    /// <summary>Has the file been edited?</summary>
    [BsonRepresentation(BsonType.Boolean)]
    public bool Edited { get; set; }

    public IEnumerable<Part> Parts { get; set; } = new List<Part>();

    private static void ThrowExceptionIfIsImpossibleType(string type)
    {
        bool containsType = new List<string>()
        {
            "image",
            "document", // TODO: think about it
            "audio",
            "video"
        }.Contains(type);

        if (!containsType)
        {
            throw new ArgumentOutOfRangeException($"Type '{type}' ist not a possible value!");
        }
    }
}