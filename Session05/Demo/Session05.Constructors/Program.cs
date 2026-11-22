// Session 05 · Demo 2 · Constructors & this  (notes §4)
// Run: dotnet run --project Session05.Constructors

using Session05.Constructors.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 05 · Constructors & this ===\n");

// ===== 4.1 Constructors (notes §4.1) =====
Console.WriteLine("--- 4.1 Constructor ---");

Console.WriteLine("new Person(\"Alice\", 30, \"alice@mail.com\"):");
Person alice = new Person("Alice", 30, "alice@mail.com");
Console.WriteLine($"→ {alice.Describe()}");

// Person has no parameterless constructor any more:
//   Person p = new Person();
//   error CS1729: 'Person' does not contain a constructor that takes 0 arguments
Console.WriteLine();

// ===== 4.2 Chaining with this(...) (notes §4.2) =====
Console.WriteLine("--- 4.2 Chaining ---");

Console.WriteLine("new Person(\"Bob\", 25):");
Person bob = new Person("Bob", 25);
Console.WriteLine($"→ {bob.Describe()}");
Console.WriteLine();

// ===== 4.3 The this keyword (notes §4.3) =====
Console.WriteLine("--- 4.3 this ---");

Point point = new Point(3, 4);
Console.WriteLine($"new Point(3, 4) → {point.Show()}   ← this.x = x");

var c = new Counter();
c.Increment();
c.Increment();
Console.WriteLine($"after 2 × Increment     → Count = {c.Count}");
c.Reset().Increment();             // Reset returns this, so we can call Increment on it
Console.WriteLine($"after Reset().Increment → Count = {c.Count}");
Console.WriteLine();

// ===== 4.4 Primary constructors (notes §4.4) =====
Console.WriteLine("--- 4.4 Primary constructor (C# 12) ---");

var employee = new Employee("Sara", 15_000m);
Console.WriteLine($"new Employee(\"Sara\", 15000) → {employee.Name}, {employee.Salary:N0}");

Console.WriteLine("\nDone. Next: Session05.Properties");
