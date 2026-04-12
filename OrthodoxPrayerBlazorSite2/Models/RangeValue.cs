using System.Diagnostics.CodeAnalysis;

namespace OrthodoxPrayerBlazorSite2.Models;

public class RangeValue<T>
{
    public required T Value { get; set; }
    public required T Min { get; set; }
    public required T Max { get; set; }

    public RangeValue() { }

    [SetsRequiredMembers]
    public RangeValue(T value, T min, T max)
    {
        Value = value;
        Min = min;
        Max = max;
    }

    public void Clamp()
    {
        if (Comparer<T>.Default.Compare(Value, Min) < 0)
            Value = Min;
        else if (Comparer<T>.Default.Compare(Value, Max) > 0)
            Value = Max;
    }

    public bool IsInRange() => Comparer<T>.Default.Compare(Value, Min) >= 0 && Comparer<T>.Default.Compare(Value, Max) <= 0;

    public override int GetHashCode() => HashCode.Combine(Value, Min, Max);

    public override bool Equals(object? obj)
    {
        if (obj is RangeValue<T> other)
            return EqualityComparer<T>.Default.Equals(Value, other.Value) &&
                   EqualityComparer<T>.Default.Equals(Min, other.Min) &&
                   EqualityComparer<T>.Default.Equals(Max, other.Max);
        return false;
    }

    public override string ToString() => $"{Value} (Range: {Min} - {Max})";
}
