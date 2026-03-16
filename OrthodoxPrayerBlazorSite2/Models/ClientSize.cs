using System.Text.Json.Serialization;

namespace OrthodoxPrayerBlazorSite2.Models;


public struct ClientSize
{
    public static ClientSize New(double value, ClientSizeEnumKind clientSizeKind = ClientSizeEnumKind.Pixels) => new ClientSize(value, clientSizeKind);

    public string Value { get; }

    public ClientSize(double value, ClientSizeEnumKind clientSizeKind = ClientSizeEnumKind.Pixels)
    {
        Value = clientSizeKind switch
        {
            ClientSizeEnumKind.Pixels => $"{value}px",
            ClientSizeEnumKind.Percentage => $"{value}%",
            ClientSizeEnumKind.Em => $"{value}em",
            ClientSizeEnumKind.Vh => $"{value}vh",
            ClientSizeEnumKind.Vw => $"{value}vw",
            _ => throw new ArgumentOutOfRangeException(nameof(clientSizeKind), clientSizeKind, null)
        };
    }

    public override string ToString() => Value;
}


public enum ClientSizeEnumKind
{
    [JsonStringEnumMemberName("x")]
    Pixels = 0,

    [JsonStringEnumMemberName("g")]
    Percentage = 1,

    [JsonStringEnumMemberName("e")]
    Em = 2,

    [JsonStringEnumMemberName("h")]
    Vh = 3,

    [JsonStringEnumMemberName("w")]
    Vw = 4,
}
