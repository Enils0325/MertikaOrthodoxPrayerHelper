using Microsoft.AspNetCore.Components;

namespace OrthodoxPrayerBlazorSite2.Pages.MainPrayers;

public partial class MealPrayer
{
    private string getBeforeAfterText() => BeforeAfterKind == BeforeAfterKindEnum.Before ? "before" : "after";
}
