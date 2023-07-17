using MongoDB.Bson.Serialization.Attributes;

namespace oag.Core.Dto;

public record RecordMinimalDto
{
    public Guid Id { get; set; }

    public Guid? ParentId { get; set; }

    public string? ReferenceCode { get; set; }

    public string? Title { get; set; } = null;

    public string? LevelOfDescription { get; set; } = null;

    [BsonIgnoreIfDefault]
    public int? Depth { get; set; } = default;
}
