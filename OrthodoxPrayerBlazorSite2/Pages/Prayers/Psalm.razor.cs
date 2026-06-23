using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages.Prayers;

public partial class Psalm
{
    [Inject]
    public NilsEventService NilsEventService { get; set; } = null!;

    private int selectedPsalm = 50;


    protected override void OnParametersSet()
    {
        base.OnParametersSet();
    }


    public void Dispose()
    {
    }
}
