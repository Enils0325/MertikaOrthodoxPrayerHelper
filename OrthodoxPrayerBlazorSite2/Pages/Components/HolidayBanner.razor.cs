using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages.Components;

public partial class HolidayBanner
{
    private DateOnly cleanMonday;
    private DateTime cleanMondayDt => cleanMonday.Dt();

    private DateOnly pascha;
    private DateTime paschaDt => pascha.Dt();

    private DateOnly firstDayOfNativityFast;
    private DateTime firstDayOfNativityFastDt => firstDayOfNativityFast.Dt();

    private DateOnly nativity;
    private DateTime nativityDt => nativity.Dt();

    private DateOnly dateApproachingNativityFast;
    private DateOnly dateApproachingGreatLent;

    private DateOnly dateToHideRecentNativity;
    private DateOnly dateToHideRecentPascha;


    [Parameter, EditorRequired]
    public DateTime Date { get; set; }

    private DateOnly DateOnly => DateOnly.FromDateTime(Date);

    protected override void OnParametersSet()
    {
        cleanMonday = HolidayCalculator.GetNextCleanMonday(DateOnly);
        pascha = HolidayCalculator.GetNextPascha(Date.Do());
        firstDayOfNativityFast = HolidayCalculator.GetNextStartOfNativityFast(DateOnly);
        nativity = HolidayCalculator.GetNextNativity(DateOnly);
        dateApproachingNativityFast = firstDayOfNativityFast.AddDays(-1 * HolidayCalculator.ApproachingThresholdDays);
        dateApproachingGreatLent = cleanMonday.AddDays(-1 * HolidayCalculator.ApproachingThresholdDays);

        dateToHideRecentNativity = HolidayCalculator.GetLastNativity(DateOnly).AddDays(HolidayCalculator.WasRecentThresholdDays);
        dateToHideRecentPascha = HolidayCalculator.GetLastPascha(DateOnly).AddDays(HolidayCalculator.WasRecentThresholdDays);

        base.OnInitialized();
    }


    private HolidaySeasonKind GetHolidaySeasonKind()
    {
        if (HolidayCalculator.IsNativity(DateOnly))
            return HolidaySeasonKind.Nativity;

        if (HolidayCalculator.IsPascha(DateOnly))
            return HolidaySeasonKind.Pascha;

        if (HolidayCalculator.IsGreatLent(DateOnly))
            return HolidaySeasonKind.GreatLent;

        if (HolidayCalculator.IsNativityFast(DateOnly))
            return HolidaySeasonKind.NativityFast;

        if (HolidayCalculator.IsNativityFast(DateOnly))
            return HolidaySeasonKind.NativityFast;

        if (DateOnly >= dateApproachingNativityFast && DateOnly < firstDayOfNativityFast)
            return HolidaySeasonKind.ApproachingNativityFast;

        if (DateOnly >= dateApproachingGreatLent && DateOnly < cleanMonday)
            return HolidaySeasonKind.ApproachingGreatLent;

        if (DateOnly <= dateToHideRecentNativity && DateOnly > HolidayCalculator.GetLastNativity(DateOnly))
            return HolidaySeasonKind.RecentlyWasNativity;

        if (DateOnly <= dateToHideRecentPascha && DateOnly > HolidayCalculator.GetLastPascha(DateOnly))
            return HolidaySeasonKind.RecentlyWasPascha;

        return HolidaySeasonKind.None;
    }


    private enum HolidaySeasonKind
    {
        None = 0,

        ApproachingGreatLent,
        GreatLent,
        Pascha,
        RecentlyWasPascha,
        
        ApproachingNativityFast,
        NativityFast,
        Nativity,
        RecentlyWasNativity,
    }
}
