using oag.Core.Models;

namespace oag.Core.Dto;

public record RecordDto : Record
{
    public IEnumerable<RecordMinimalDto> ParentsHierarchy { get; set; } = new List<RecordMinimalDto>();

    public string? ParentsHierarchyReference { get; set; }
}
