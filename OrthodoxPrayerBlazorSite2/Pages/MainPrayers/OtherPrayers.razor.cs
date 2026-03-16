using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages.MainPrayers;

public partial class OtherPrayers
{
    [Parameter, EditorRequired] public DateTime Date { get; set; }
    [Inject] public NilsEventService NilsEventService { get; set; } = null!;


    private OtherPrayerChoiceKind PrayerChoice { get; set; } = OtherPrayerChoiceKind.None;

    protected override async Task OnParametersSetAsync()
    {
        await OnRandomClicked();
        NilsEventService.OnRandomClicked += OnRandomClicked;
        base.OnParametersSet();
    }


    public async Task OnRandomClicked()
    {
        // SelectedIndexOutOf3 = MainUtil.GetRandomIndex(25);
        StateHasChanged();
    }


    public void Dispose()
    {
        NilsEventService.OnRandomClicked -= OnRandomClicked;
    }

}
