using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages.Components;

public partial class HolidayBanner
{
    private DateOnly cleanMonday;
    private DateOnly pascha;
    private DateOnly firstDayOfNativityFast;
    private DateOnly nativity;

    private DateTime cleanMondayDt => cleanMonday.ToDateTimeAtTime0();
    private DateTime paschaDt => pascha.ToDateTimeAtTime0();
    private DateTime firstDayOfNativityFastDt => firstDayOfNativityFast.ToDateTimeAtTime0();
    private DateTime nativityDt => nativity.ToDateTimeAtTime0();

    [Parameter, EditorRequired]
    public DateTime Date { get; set; }

    private DateOnly DateOnly => DateOnly.FromDateTime(Date);


    protected override void OnInitialized()
    {
        cleanMonday = HolidayCalculator.GetCleanMonday(DateOnly);
        pascha = HolidayCalculator.GetPascha(Date.Year);
        firstDayOfNativityFast = HolidayCalculator.GetStartOfNativityFast(Date.Year);
        nativity = new DateOnly(Date.Year, 12, 25);

        base.OnInitialized();
    }


    private HolidaySeasonKind GetHolidaySeasonKind()
    {
        if (HolidayCalculator.IsGreatLent(DateOnly))            
            return HolidaySeasonKind.GreatLent;

        else if (HolidayCalculator.IsPascha(DateOnly))          
            return HolidaySeasonKind.Pascha;

        else if (HolidayCalculator.IsNativityFast(DateOnly))    
            return HolidaySeasonKind.NativityFast;

        else if (HolidayCalculator.IsNativity(DateOnly))        
            return HolidaySeasonKind.Nativity;

        else if (HolidayCalculator.IsNativityFast(DateOnly))    
            return HolidaySeasonKind.NativityFast;

        else if ((Date - firstDayOfNativityFastDt).TotalDays <= HolidayCalculator.ApproachingThresholdDays)
            return HolidaySeasonKind.ApproachingNativityFast;

        else if ((Date - cleanMondayDt).TotalDays <= HolidayCalculator.ApproachingThresholdDays)
            return HolidaySeasonKind.ApproachingGreatLent;

        else if (DateOnly > nativity && (Date - nativityDt).TotalDays <= HolidayCalculator.WasRecentThresholdDays)
            return HolidaySeasonKind.RecentlyWasNativity;

        else if (DateOnly > pascha && (Date - paschaDt).TotalDays <= HolidayCalculator.WasRecentThresholdDays)
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
