using oag.Core.Types;

namespace oag.Core.Helper;

public static class NewBaseType
{
    public static bool IsValidLevelOfDescription(this string level)
    {
        return IsadLevelsOfDescription.All.Contains(level);
    }
}
