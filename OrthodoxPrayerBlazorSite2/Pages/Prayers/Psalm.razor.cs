using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages.Prayers;

public partial class Psalm
{
    [Inject]
    public NilsEventService NilsEventService { get; set; } = null!;

    private readonly IEnumerable<int> morningDebugPsalms = [102, 142, 5, 50, 62];
    private readonly IEnumerable<int> eveningDebugPsalms = [120, 133, 140, 4, 90];

    private readonly IEnumerable<int> morningDebugBriefPsalms = [50, 62];
    private readonly IEnumerable<int> eveningDebugBriefPsalms = [120, 133, 4,];


    private readonly IEnumerable<int> morningPsalms = [102, 142, 5, 50, 62];
    private readonly IEnumerable<int> eveningPsalms = [120, 133, 140, 4, 90];

    private readonly IEnumerable<int> morningBriefPsalms = [50, 62];
    private readonly IEnumerable<int> eveningBriefPsalms = [120, 133, 4,];


    private int selectedPsalm = 50;

    protected override void OnParametersSet()
    {
        // subscribe to external randomize event
        NilsEventService.OnRandomClicked += OnRandomClicked;

        SelectRandomPsalm();

        base.OnParametersSet();
    }


    private void SelectRandomPsalm()
    {
        if (MainUtil.IsDebug)
        {
            if (IsBrief)
            {
                selectedPsalm = PsalmTimeOfDayKind == PsalmTimeOfDayKindEnum.Morning
                    ? morningDebugBriefPsalms.GetRandomItem()
                    : eveningDebugBriefPsalms.GetRandomItem();
            }
            else
            {
                selectedPsalm = PsalmTimeOfDayKind == PsalmTimeOfDayKindEnum.Morning
                    ? morningDebugPsalms.GetRandomItem()
                    : eveningDebugPsalms.GetRandomItem();
            }
        }
        else
        {
            if (IsBrief)
            {
                selectedPsalm = PsalmTimeOfDayKind == PsalmTimeOfDayKindEnum.Morning
                    ? morningBriefPsalms.GetRandomItem()
                    : eveningBriefPsalms.GetRandomItem();
            }
            else
            {
                selectedPsalm = PsalmTimeOfDayKind == PsalmTimeOfDayKindEnum.Morning
                    ? morningPsalms.GetRandomItem()
                    : eveningPsalms.GetRandomItem();
            }
        }
    }


    public async Task OnRandomClicked()
    {
        SelectRandomPsalm();
        StateHasChanged();
    }


    public void Dispose()
    {
        NilsEventService.OnRandomClicked -= OnRandomClicked;
    }
}
