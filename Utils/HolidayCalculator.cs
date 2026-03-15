using System;
using System.Globalization;

namespace OrthodoxPrayerBlazorSite2.Utils;

public static class HolidayCalculator
{
    public const int ApproachingThresholdDays = 21;
    public const int WasRecentThresholdDays = 14;


    public static DateOnly GetStartOfNativityFast(int year) => new DateOnly(year, 11, 15);

    public static bool IsNativityFast(DateOnly date)
    {
        var start = GetStartOfNativityFast(date.Year);
        var end = GetNativity(date.Year);
        return date >= start && date < end.AddDays(1);
    }


    public static bool IsNativity(DateOnly date) => date == GetNativity(date.Year);
    public static DateOnly GetNativity(int year) => new DateOnly(year, 12, 25);



    public static DateOnly GetCleanMonday(DateOnly date) => GetPascha(date.Year).AddDays(-48);

    public static bool IsGreatLent(DateOnly date)
    {
        var easter = GetPascha(date.Year);
        var cleanMonday = GetCleanMonday(date);
        var holySaturday = easter.AddDays(-1);

        return date >= cleanMonday && date <= holySaturday;
    }

    public static bool IsPascha(DateOnly date) => date == GetPascha(date.Year);
    public static DateOnly GetPascha(int year)
    {
        // Algorithm based on the Meeus/Jones/Butcher method for the Julian calendar
        int a = year % 4;
        int b = year % 7;
        int c = year % 19;

        int d = (19 * c + 15) % 30;
        int e = (2 * a + 4 * b - d + 34) % 7;

        int month = (d + e + 114) / 31; // 3=March, 4=April in Julian calendar
        int day = ((d + e + 114) % 31) + 1;

        var julianCalendar = new JulianCalendar();
        var julianDate = new DateTime(year, month, day, julianCalendar);

        return DateOnly.FromDateTime(julianDate);
    }
}
