namespace OrthodoxPrayerBlazorSite2.Workers;

public class NilsAppState
{
    private LanguageKindEnum _selectedLanguageKind { get; set; } = LanguageKindEnum.EnglishModern;

    public LanguageKindEnum SelectedLanguageKind
    {
        get => _selectedLanguageKind;
        set
        {
            _selectedLanguageKind = value;
            OnSelectedLanguageKindChanged?.Invoke();
        }
    }

    public event Action? OnSelectedLanguageKindChanged;
}
