namespace OrthodoxPrayerBlazorSite2.Utils;

public static class Extensions
{
    public static DateTime ToDateTimeAtTime0(this DateOnly dateOnly)
    {
        return new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);
    }
}
