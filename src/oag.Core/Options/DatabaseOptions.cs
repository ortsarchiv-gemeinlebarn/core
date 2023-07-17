namespace oag.Core.Options;

public class DatabaseOptions
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string RecordsCollection { get; set; } = null!;
}