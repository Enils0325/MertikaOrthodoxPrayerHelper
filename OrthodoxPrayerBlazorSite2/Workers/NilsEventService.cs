namespace OrthodoxPrayerBlazorSite2.Workers;

public class NilsEventService
{
    public event Func<LanguageKindEnum, Task> OnLanguageChanged = null!;
    public void NotifyLanguageChanged(LanguageKindEnum languageKind) => OnLanguageChanged?.Invoke(languageKind);

}
