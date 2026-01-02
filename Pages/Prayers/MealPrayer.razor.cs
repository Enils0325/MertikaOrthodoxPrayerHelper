using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages.Prayers;

public partial class MealPrayer
{
    private string getBeforeAfterText() => BeforeAfterKind == BeforeAfterKindEnum.Before ? "before" : "after";
}
