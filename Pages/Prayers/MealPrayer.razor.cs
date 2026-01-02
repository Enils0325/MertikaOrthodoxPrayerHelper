using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages.Prayers;

public partial class MealPrayer
{
    [Parameter]
    public MealKindEnum MealKind { get; set; } = MealKindEnum.Breakfast;

    [Parameter]
    public BeforeAfterKindEnum BeforeAfterKind { get; set; } = BeforeAfterKindEnum.Before;

    private string getBeforeAfterText() => BeforeAfterKind == BeforeAfterKindEnum.Before ? "before" : "after";
}
