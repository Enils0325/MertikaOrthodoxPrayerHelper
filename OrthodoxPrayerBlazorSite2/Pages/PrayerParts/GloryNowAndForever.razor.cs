using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages.PrayerParts;

public partial class GloryNowAndForever
{
    [Parameter]
    public GloryNowOptionKind GloryNowOption { get; set; } = GloryNowOptionKind.All;
}

public enum GloryNowOptionKind
{
    All,
    FirstPortion,
    LastPortion,
}
