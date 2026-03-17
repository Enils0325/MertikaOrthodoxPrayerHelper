namespace OrthodoxPrayerBlazorSite2.Utils;

public static class Extensions
{
    public static DateTime ToDateTime(this DateOnly dateOnly)
    {
        return new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);
    }

    public static DateOnly ToDateOnly(this DateTime dateTime)
    {
        return new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
    }

    public static T GetRandomItem<T>(this IEnumerable<T> items)
        {
            if (items == null || !items.Any())
                throw new ArgumentException("The collection is empty.");
    
            var random = new Random();
            int index = random.Next(items.Count());

            return items.ElementAt(index);
    }
}
