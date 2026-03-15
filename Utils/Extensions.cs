namespace OrthodoxPrayerBlazorSite2.Utils;

public static class Extensions
{
    public static DateTime Dt(this DateOnly dateOnly)
    {
        return new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);
    }
    public static DateOnly Do(this DateTime dateTime)
    {
        return new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
    }
}
