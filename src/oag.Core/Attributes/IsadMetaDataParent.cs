namespace oag.Core.Attributes;

[System.AttributeUsage(System.AttributeTargets.Property)]
public class IsadMetaDataParent : System.Attribute
{
    private string number;
    private string englishName;
    private string germanName;

    public IsadMetaDataParent(string number, string englishName, string germanName)
    {
        this.number = number;
        this.englishName = englishName;
        this.germanName = germanName;
    }
}
