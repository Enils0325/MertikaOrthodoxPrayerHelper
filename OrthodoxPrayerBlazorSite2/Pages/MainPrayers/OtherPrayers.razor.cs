using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages.MainPrayers;

public partial class OtherPrayers
{
    [Inject] public NilsEventService NilsEventService { get; set; } = null!;


    [Parameter, EditorRequired] 
    public DateTime Date { get; set; }


    [Parameter, EditorRequired]
    public EventCallback<OtherPrayerChoiceKind> OnPrayerSelected { get; set; }


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
