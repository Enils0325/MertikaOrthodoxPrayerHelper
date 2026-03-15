using System;
using System.Globalization;

namespace OrthodoxPrayerBlazorSite2.Utils;

public static class HolidayCalculator
{
    public const int ApproachingThresholdDays = 21;
    public const int WasRecentThresholdDays = 14;


    public static DateOnly GetStartOfNativityFast(DateOnly date) => GetNativity(date).AddDays(-40);

    public static bool IsNativityFast(DateOnly date)
    {
        var start = GetStartOfNativityFast(date);
        var end = GetNativity(date);
        return date >= start && date < end.AddDays(1);
    }


    public static bool IsNativity(DateOnly date) => date == GetNativity(date);
    public static DateOnly GetNativity(DateOnly date)
    {
        var nativityThisYear = new DateOnly(date.Year, 12, 25);
        if (date > nativityThisYear)
            return new DateOnly(date.Year + 1, 12, 25);
        else
            return nativityThisYear;
    }

    public static DateOnly GetCleanMonday(DateOnly date) => GetPascha(date).AddDays(-48);

    public static bool IsGreatLent(DateOnly date)
    {
        var pascha = GetPascha(date);
        var cleanMonday = GetCleanMonday(date);

        return date >= cleanMonday && date < pascha.AddDays(1);
    }

    public static bool IsPascha(DateOnly date) => date == GetPascha(date.Year);
    public static DateOnly GetPascha(DateOnly date)
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
