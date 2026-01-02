namespace OrthodoxPrayerBlazorSite2.Pages;

public partial class Home
{
    private DateTime Date { get; set; } = DateTime.Now;
    private MainPrayerChoiceKind MainPrayerChoice { get; set; } = MainPrayerChoiceKind.None;

}

public enum MainPrayerChoiceKind
{
    None,
    BeforeMeal,
    AfterMeal,
    MorningPrayer,
    EveningPrayer,
}
