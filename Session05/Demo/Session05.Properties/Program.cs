// Session 05 · Demo 3 · Properties & Access Modifiers  (notes §5)
// Run: dotnet run --project Session05.Properties

using Session05.Properties.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 05 · Properties & Access Modifiers ===\n");

// ===== 5.2 Access modifiers (notes §5.2) =====
Console.WriteLine("--- 5.2 Access modifiers ---");

var vault = new Vault();
Console.WriteLine($"public    vault.Label     = {vault.Label}");
Console.WriteLine($"internal  vault.Branch    = {vault.Branch}");
Console.WriteLine($"private   _code via CheckCode(1234) = {vault.CheckCode(1234)}");
Console.WriteLine($"protected Level via SmallVault.ReadLevel() = {new SmallVault().ReadLevel()}");
// vault._code = 0;   // error CS0122: 'Vault._code' is inaccessible due to its protection level
// vault.Level = 0;   // error CS0122: 'Vault.Level' is inaccessible due to its protection level
Console.WriteLine();

// ===== 5.3 Auto-implemented properties (notes §5.3) =====
Console.WriteLine("--- 5.3 Auto properties, private set, init ---");

var laptop = new Product { Name = "Laptop", Sku = "LP-01", Price = 25_000m };
laptop.Restock(5);
laptop.Restock(3);
Console.WriteLine($"{laptop.Name} ({laptop.Sku}): price {laptop.Price:N0}, stock {laptop.Stock}");
// laptop.Stock = 100;
//   error CS0272: The property or indexer 'Product.Stock' cannot be used in this context because the set accessor is inaccessible
// laptop.Sku = "XX";
//   error CS8852: Init-only property or indexer 'Product.Sku' can only be assigned in an object initializer, ...
Console.WriteLine();

// ===== 5.4 Full property with a backing field (notes §5.4) =====
Console.WriteLine("--- 5.4 Validation in set ---");

try
{
    laptop.Price = -10;
}
catch (ArgumentException ex)
{
    Console.WriteLine($"laptop.Price = -10 → {ex.GetType().Name}: {ex.Message}");
}
Console.WriteLine($"price is still {laptop.Price:N0}");

var discount = new Discount { Percent = 15 };
Console.WriteLine($"Discount.Percent = {discount.Percent}   (C# 14 'field' keyword)");
try
{
    discount.Percent = 150;
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("Discount.Percent = 150 → ArgumentOutOfRangeException");
}
Console.WriteLine();

// ===== 5.5 Computed properties (notes §5.5) =====
Console.WriteLine("--- 5.5 Computed properties ---");

var r = new Rectangle { Width = 4, Height = 6 };
Console.WriteLine($"4 × 6  → Area = {r.Area}, Perimeter = {r.Perimeter}");
r.Width = 10;
Console.WriteLine($"10 × 6 → Area = {r.Area}, Perimeter = {r.Perimeter}   ← updated automatically");
// r.Area = 5;   // error CS0200: Property or indexer 'Rectangle.Area' cannot be assigned to -- it is read only

Console.WriteLine("\nDone. Next: Session05.StaticMembers");
