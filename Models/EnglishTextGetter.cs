namespace OrthodoxPrayerBlazorSite2.Models;

public class EnglishTextGetter
{
    private readonly EnglishKindEnum englishKind;

    public EnglishTextGetter(EnglishKindEnum englishKind)
    {
        this.englishKind = englishKind;
    }


    public string Whom()
    {
        return englishKind switch
        {
            EnglishKindEnum.Old => "whom",
            EnglishKindEnum.Contemporary => "who",
            _ => "who"
        };
    }


    public string Thee(bool capitalizeFirstLetter)
    {
        var text = englishKind switch
        {
            EnglishKindEnum.Old => "thee",
            EnglishKindEnum.Contemporary => "you",
            _ => "you"
        };

        if (capitalizeFirstLetter)
        {
            text = char.ToUpper(text[0]) + text.Substring(1);
        }

        return text;
    }


    public string Hast()
    {
        return englishKind switch
        {
            EnglishKindEnum.Old => "hast",
            EnglishKindEnum.Contemporary => "has",
            _ => "has"
        };
    }
}
