using System;
using Moq;
using Xunit;
using OrthodoxPrayerBlazorSite2.Utils;

namespace OrthodoxPrayerBlazorSite2.UnitTests;

public class HolidayCalculator_IsNativityAndLent_Tests
{
    [Theory]
    [InlineData(2023, 12, 25, true)]
    [InlineData(2024, 12, 25, true)]
    [InlineData(2023, 12, 24, false)]
    [InlineData(2024, 12, 26, false)]
    public void IsNativity_ReturnsExpected(int year, int month, int day, bool expected)
    {
        var date = new DateOnly(year, month, day);
        var actual = HolidayCalculator.IsNativity(date);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNativity_FromExtension()
    {
        var date = (new DateTime(2026, 12, 25, 12, 30, 30, DateTimeKind.Local)).Do();
        var isNativity = HolidayCalculator.IsNativity(date);
        Assert.True(isNativity);
    }

    [Theory]
    [InlineData(2024, 3, 18, true)]  // Clean Monday 2024
    [InlineData(2024, 5, 4, true)]   // Holy Saturday 2024
    [InlineData(2023, 2, 27, true)]  // Clean Monday 2023
    [InlineData(2023, 4, 15, true)]  // Holy Saturday 2023
    [InlineData(2024, 3, 17, false)]
    [InlineData(2024, 5, 5, false)]
    [InlineData(2023, 2, 26, false)]
    [InlineData(2023, 4, 16, false)]
    public void IsGreatLent_ReturnsExpected(int year, int month, int day, bool expected)
    {
        var date = new DateOnly(year, month, day);
        var actual = HolidayCalculator.IsGreatLent(date);
        Assert.Equal(expected, actual);
    }
}
