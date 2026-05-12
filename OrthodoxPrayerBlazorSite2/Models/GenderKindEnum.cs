namespace OrthodoxPrayerBlazorSite2.Models;

public enum GenderKindEnum
{
    Unknown,
    Male,
    Female,
}

public static class GenderKindEnumExtensions
{
    public static string Him(this GenderKindEnum genderKind, string? customUnknown = null)
    {
        customUnknown = string.IsNullOrWhiteSpace(customUnknown) ? "him or her" : customUnknown;
        return genderKind switch
        {
            GenderKindEnum.Male => "him",
            GenderKindEnum.Female => "her",
            GenderKindEnum.Unknown => customUnknown,
            _ => customUnknown,
        };
    }
    
    public static string His(this GenderKindEnum genderKind, string? customUnknown = null)
    {
        customUnknown = string.IsNullOrWhiteSpace(customUnknown) ? "his or her" : customUnknown;
        return genderKind switch
        {
            GenderKindEnum.Male => "his",
            GenderKindEnum.Female => "her",
            GenderKindEnum.Unknown => customUnknown,
            _ => customUnknown,
        };
    }

    public static string He(this GenderKindEnum genderKind, string? customUnknown = null)
    {
        customUnknown = string.IsNullOrWhiteSpace(customUnknown) ? "he or she" : customUnknown;
        return genderKind switch
        {
            GenderKindEnum.Male => "he",
            GenderKindEnum.Female => "she",
            GenderKindEnum.Unknown => customUnknown,
            _ => customUnknown,
        };
    }
}
