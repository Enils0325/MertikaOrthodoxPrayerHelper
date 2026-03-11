using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages;

public partial class Home
{
    [Inject]
    public NilsEventService NilsEventService { get; set; } = null!;

    private IEnumerable<MainPrayerChoiceKind> choiceKindsWithNoRandom = [
        MainPrayerChoiceKind.Other,
        MainPrayerChoiceKind.None,
    ];

    private DateTime Date { get; set; } = DateTime.Now;
    private MainPrayerChoiceKind MainPrayerChoice { get; set; } = MainPrayerChoiceKind.None;
}
