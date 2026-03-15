using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages;

public partial class Home : IDisposable
{
    [Inject]
    public NilsEventService NilsEventService { get; set; } = null!;

    private bool IsLoading { get; set; } = false;

    private IEnumerable<MainPrayerChoiceKind> choiceKindsWithNoRandom = [
        MainPrayerChoiceKind.Other,
        MainPrayerChoiceKind.None,
    ];

    private DateTime Date { get; set; } = DateTime.Now;
    private MainPrayerChoiceKind MainPrayerChoice { get; set; } = MainPrayerChoiceKind.None;

    protected override async Task OnInitializedAsync()
    {
        NilsEventService.OnRandomClicked += NilsEventService_OnRandomClicked;
        await base.OnInitializedAsync();
    }

    private async Task NilsEventService_OnRandomClicked()
    {
        IsLoading = true;
        StateHasChanged();

        await Task.Delay(500);

        IsLoading = false;
        StateHasChanged();
    }

    private async Task SetMainPrayerKind(MainPrayerChoiceKind choiceKind)
    {
        IsLoading = true;
        StateHasChanged();
        await Task.Delay(300);

        this.MainPrayerChoice = choiceKind;

        IsLoading = false;
        StateHasChanged();
    }

    public void Dispose()
    {
        NilsEventService.OnRandomClicked -= NilsEventService_OnRandomClicked;
    }
}
