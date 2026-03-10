using System.Reflection;
using System.Text.Json;

namespace OrthodoxPrayerBlazorSite2.Resources;

public static class ResourceReaderUtility
{
    public static string GetResourceText(string fileName)
    {
        string resourceText = string.Empty;

        try
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"{typeof(Nothing).Namespace}.{fileName}";

            using Stream stream = assembly.GetManifestResourceStream(resourceName)!;
            using StreamReader reader = new StreamReader(stream);

            resourceText = reader.ReadToEnd();
        }
        catch { }

        return resourceText;
    }
}

public class Nothing { }