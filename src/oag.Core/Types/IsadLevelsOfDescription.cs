namespace oag.Core.Types;

public static class IsadLevelsOfDescription
{
    public const string FondsGroup = "fonds-group";
    public const string Fonds = "fonds";
    public const string FondsPart = "fonds-part";
    public const string Serie = "series";
    public const string File = "file";
    public const string Item = "item";

    public static IEnumerable<string> All
    {
        get => new List<string>() {
            IsadLevelsOfDescription.FondsGroup,
            IsadLevelsOfDescription.Fonds,
            IsadLevelsOfDescription.FondsPart,
            IsadLevelsOfDescription.Serie,
            IsadLevelsOfDescription.File,
            IsadLevelsOfDescription.Item,
        };
    }
}