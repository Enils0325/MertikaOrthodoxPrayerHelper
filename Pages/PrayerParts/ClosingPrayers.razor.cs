using Microsoft.AspNetCore.Components;
using OrthodoxPrayerBlazorSite2.Resources;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace OrthodoxPrayerBlazorSite2.Pages.PrayerParts;

public partial class ClosingPrayers(HttpClient httpClient)
{
    [Parameter, EditorRequired]
    public DateTime Date { get; set; }

    [Parameter, EditorRequired]
    public HeadingKindEnum HeadingKind { get; set; }

    [CascadingParameter]
    public LanguageKindEnum LanguageKind { get; set; } = LanguageKindEnum.EnglishModern;

    private bool IsLoading { get; set; } = true;

    private string SaintText = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await setStaintText();
        await base.OnInitializedAsync();
    }

    private async Task setStaintText()
    {
        var saintText = "";
        try
        {
            IsLoading = true;
            StateHasChanged();

            var saintsJson = ResourceReaderUtility.GetResourceText($"SaintDays.json");
            var saintDaysJsonItems = JsonSerializer.Deserialize<List<OrthodoxSaintDaysJsonItem>>(saintsJson) ?? [];
            var saintDayItem = saintDaysJsonItems.FirstOrDefault(s => s.Date.Month == Date.Date.Month && s.Date.Day == Date.Day);

            saintText = saintDayItem?.SaintOfTheDay ?? string.Empty;
        }
        catch
        {
            saintText = string.Empty;
        }
        finally
        {
            IsLoading = false;
        }

        SaintText = saintText;
    }

    private string ocaSaintLink => $"https://www.oca.org/saints/lives/{Date:yyyy/MM/dd}";
}
