using System;
using System.Globalization;

namespace OrthodoxPrayerBlazorSite2.Utils;

public static class HolidayCalculator
{
    /// <summary>
    /// Returns true if the provided date is within Eastern Orthodox Great Lent (from Clean Monday through Holy Saturday).
    /// </summary>
    public static bool GetIfLent(DateOnly date)
    {
        var easter = GetPascha(date.Year);
        var cleanMonday = easter.AddDays(-48);
        var holySaturday = easter.AddDays(-1);
        return date >= cleanMonday && date <= holySaturday;
    }

    /// <summary>
    /// Returns true if the provided date is within the Nativity Fast (the 40 days before Nativity: Nov 15 through Dec 24 inclusive).
    /// </summary>
    public static bool GetIfNativityFast(DateOnly date)
    {
        var start = new DateOnly(date.Year, 11, 15);
        var end = new DateOnly(date.Year, 12, 24);
        return date >= start && date <= end;
    }

    // Compute Orthodox Easter (Pascha) for the given year using the Julian calendrical algorithm and convert to Gregorian date.
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
