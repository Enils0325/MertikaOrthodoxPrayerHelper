using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace OrthodoxPrayerBlazorSite2.Pages.PrayerParts;

public partial class ClosingPrayers
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


            using HttpClient client = new HttpClient();
            var htmlContent = await client.GetStringAsync(ocaSaintLink);

            var regexMatches = Regex.Matches(htmlContent, @"<h2 class=""name"">[\w\d\s:<>!\-,'\(\)\[\]“”]+</h2>", RegexOptions.IgnoreCase);
            var saintOfToday = "";
            foreach (Match regexMatch in regexMatches)
            {
                var matchText = regexMatch.Value.Replace("<h2 class=\"name\">", "").Replace("</h2>", "").Trim();
                if (ShouldSkipFoundSaintText(matchText))
                    continue;

                if (matchText.StartsWith("Repose of "))
                    matchText = matchText.Replace("Repose of ", "");

                if (matchText.StartsWith("Dormition of "))
                    matchText = matchText.Replace("Dormition of ", "");

                if (matchText.StartsWith("Commemoration of the"))
                    matchText = matchText.Replace("Commemoration of the", "The");

                saintOfToday = matchText;
                continue;
            }

            saintText = saintOfToday;
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

    private readonly string[] daysOfTheWeek = ["monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"];

    private readonly string[] textsToSkip = [
        "HOLY PASCHA: The Resurrection of Our Lord",
        "Antipascha: Saint Thomas Sunday",
        "Day of Rejoicing",
        "Midfeast of Pentecost",
        "Commemoration of the Apparition of the Sign of the Precious Cross Over Jerusalem, in 351 AD",
        "Commemoration of the Founding of Constantinople",
        "Leavetaking of Pascha",
        "The Ascension of our Lord",
        "Third Finding of the Honorable Head of the Holy Glorious Prophet, Forerunner and Baptist John",
        "Holy Pentecost",
        "Synaxis of All Saints",
        "Synaxis of the Holy, Glorious and All-Praised Twelve Apostles",
        "The Beheading of the Holy Glorious Prophet, Forerunner, and Baptist John",
        "The Placing of the Cincture (Sash) of the Mother of God",
        "Church New Year",
        "Commemoration of the Miracle of the Archangel Michael at Colossae",
        "The Nativity of our Most Holy Lady the Mother of God and Ever-Virgin Mary",
        "The Universal Exaltation of the Precious and Life-Giving Cross",
        ];

    private bool ShouldSkipFoundSaintText(string matchText)
    {
        if (matchText.StartsWith("Great and holy", stringComparison)) return true;
        if (matchText.StartsWith("Postfeast of Pentecost", stringComparison)) return true;
        if (matchText.StartsWith("Translation of the relics of", stringComparison)) return true;
        if (matchText.StartsWith("Procession of the ", stringComparison)) return true;
        if (matchText.StartsWith("Afterfeast of the ", stringComparison)) return true;
        if (matchText.StartsWith("Forefeast of the ", stringComparison)) return true;
        if (matchText.StartsWith("Commemoration of the ", stringComparison)) return true;

        if (matchText.Contains("icon of the mother of god", stringComparison)) return true;
        if (matchText.Contains("transfiguration of our lord", stringComparison)) return true;
        if (matchText.Contains("of the mother of god", stringComparison)) return true;
        if (matchText.Contains("of the Relics of", stringComparison)) return true;

        foreach (var textToSkip in textsToSkip)
        {
                if (matchText.Equals(textToSkip, stringComparison))
                    return true;
        }

        if (daysOfTheWeek.Select(d => $"{d} of").Contains(matchText.ToLower())) return true;
        if (daysOfTheWeek.Select(d => $"memorial {d}").Contains(matchText.ToLower())) return true;

        return false;
    }

    private const StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase;

    private string ocaSaintLink => $"https://www.oca.org/saints/lives/{Date:yyyy/MM/dd}";
}
