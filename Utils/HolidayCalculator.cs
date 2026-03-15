using System;
using System.Globalization;

namespace OrthodoxPrayerBlazorSite2.Utils;

public static class HolidayCalculator
{
    public const int ApproachingThresholdDays = 21;
    public const int WasRecentThresholdDays = 14;


    public static DateOnly GetStartOfNativityFast(DateOnly date) => GetNextNativity(date).AddDays(-40);

    public static bool IsNativityFast(DateOnly date)
    {
        var start = GetStartOfNativityFast(date);
        var end = GetNextNativity(date);
        return date >= start && date < end.AddDays(1);
    }


    public static bool IsNativity(DateOnly date) => date == GetNativity(date.Year);
    public static DateOnly GetNativity(int year) => new DateOnly(year, 12, 25);
    public static DateOnly GetNextNativity(DateOnly date)
    {
        var nativityThisYear = GetNativity(date.Year);
        if (date > nativityThisYear)
            return GetNativity(date.Year + 1);
        else
            return nativityThisYear;
    }

    public static DateOnly GetNextCleanMonday(DateOnly date) => GetNextPascha(date).AddDays(-48);

    public static bool IsGreatLent(DateOnly date)
    {
        var pascha = GetNextPascha(date);
        var cleanMonday = GetNextCleanMonday(date);

        return date >= cleanMonday && date < pascha.AddDays(1);
    }

    public static bool IsPascha(DateOnly date) => date == GetPascha(date.Year);
    public static DateOnly GetNextPascha(DateOnly date)
    {
        var paschaThisYear = GetPascha(date.Year);
        if (date > paschaThisYear)
            return GetPascha(date.Year + 1);
        else
            return paschaThisYear;
    }

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
