using Microsoft.JSInterop;

namespace OrthodoxPrayerBlazorSite2.Utils;

public class LocalStorageService(IJSRuntime jsRuntime)
{
    public async Task<int?> GetIntAsync(string key)
    {
        var value = await jsRuntime.InvokeAsync<string?>("localStorage.getItem", key);

        if (int.TryParse(value, out var parsedValue))
        {
            return parsedValue;
        }

        return null;
    }

    public async Task SetIntAsync(string key, int value)
    {
        await jsRuntime.InvokeVoidAsync("localStorage.setItem", key, value.ToString());
    }
}
