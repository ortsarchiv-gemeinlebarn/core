namespace oag.Core.Dto;

public record RecordOrentationDto : RecordMinimalDto
{
    public IEnumerable<RecordMinimalDto> Siblings { get; set; } = new List<RecordMinimalDto>();

    public IEnumerable<RecordMinimalDto> Children { get; set; } = new List<RecordMinimalDto>();

    public IEnumerable<RecordMinimalDto> ParentsHierarchy { get; set; } = new List<RecordMinimalDto>();

    public string? ParentsHierarchyReference { get; set; }
}
