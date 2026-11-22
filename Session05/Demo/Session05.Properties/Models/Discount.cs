namespace Session05.Properties.Models;

// C# 14: 'field' is the compiler-made backing field, so no _percent is needed.
public class Discount
{
    public decimal Percent
    {
        get;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 100);
            field = value;
        }
    }
}
