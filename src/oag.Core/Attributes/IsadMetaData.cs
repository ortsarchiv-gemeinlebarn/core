namespace oag.Core.Attributes;

[System.AttributeUsage(System.AttributeTargets.Property)]
public class IsadMetaData : System.Attribute
{
    private string number;
    private string englishName;
    private string germanName;

    public IsadMetaData(string number, string englishName, string germanName)
    {
        this.number = number;
        this.englishName = englishName;
        this.germanName = germanName;
    }
}
