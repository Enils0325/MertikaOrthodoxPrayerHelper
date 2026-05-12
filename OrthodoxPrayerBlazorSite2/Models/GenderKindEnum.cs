namespace OrthodoxPrayerBlazorSite2.Models;

public enum GenderKindEnum
{
    Unknown,
    Male,
    Female,
}

public static class GenderKindEnumExtensions
{
    public static string Him(this GenderKindEnum genderKind)
    {
        return genderKind switch
        {
            GenderKindEnum.Male => "him",
            GenderKindEnum.Female => "her",
            GenderKindEnum.Unknown => "him or her",
            _ => "him or her",
        };
    }
    
    public static string His(this GenderKindEnum genderKind)
    {
        return genderKind switch
        {
            GenderKindEnum.Male => "his",
            GenderKindEnum.Female => "her",
            GenderKindEnum.Unknown => "his or her",
            _ => "his or her",
        };
    }

    public static string He(this GenderKindEnum genderKind)
    {
        return genderKind switch
        {
            GenderKindEnum.Male => "he",
            GenderKindEnum.Female => "she",
            GenderKindEnum.Unknown => "he or she",
            _ => "he or she",
        };
    }
}
