namespace OrthodoxPrayerBlazorSite2.Utils;

public static class MainUtil
{
    public static int GetRandomIndex(int itemCount) => GetRandomInt(0, itemCount);
    public static int GetRandomInt(int min, int max) => Random.Shared.Next(min, max);
}
