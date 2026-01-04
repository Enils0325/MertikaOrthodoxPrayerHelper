using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages;

public abstract partial class OrthodoxPrayerBasePage : ComponentBase
{
    [Inject]
    protected NilsEventService NilsEventService { get; private set; } = null!;

    protected LanguageKindEnum LanguageKind { get; set; } = LanguageKindEnum.EnglishModern;


    protected override void OnParametersSet()
    {
        NilsEventService.OnLanguageChanged += OnLanguageChanged;
        base.OnParametersSet();
    }


    public async Task OnLanguageChanged(LanguageKindEnum languageKind)
    {
        LanguageKind = languageKind;
        StateHasChanged();
    }

    protected virtual void Dispose()
    {
        NilsEventService.OnLanguageChanged += OnLanguageChanged;
    }
}
