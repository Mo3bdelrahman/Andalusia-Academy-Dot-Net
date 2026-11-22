namespace Session05.Properties.Models;

public class Product
{
    // Auto-implemented: the compiler makes the hidden field.
    public string Name { get; set; } = "";

    // init (C# 9): can be set only while the object is being created.
    public string Sku { get; init; } = "";

    // Readable by anyone, writable only inside this class.
    public int Stock { get; private set; }

    // Full property: a private backing field + validation in set.
    private decimal _price;
    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentException("Price cannot be negative.", nameof(value));
            _price = value;
        }
    }

    public void Restock(int units)
    {
        Stock += units;
    }
}
