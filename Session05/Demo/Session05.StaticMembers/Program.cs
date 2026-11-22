// Session 05 · Demo 4 · Static Members  (notes §6)
// Run: dotnet run --project Session05.StaticMembers

using Session05.StaticMembers.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 05 · Static Members ===\n");

// ===== 6.2 Utility methods (notes §6.2) =====
// Called on the class name, no object needed.
Console.WriteLine("--- 6.2 Utility methods ---");

double pi = MathHelper.Pi;
int sq = MathHelper.Square(5);
double area = MathHelper.CircleArea(3);
Console.WriteLine($"MathHelper.Pi            = {pi}");
Console.WriteLine($"MathHelper.Square(5)     = {sq}");
Console.WriteLine($"MathHelper.CircleArea(3) = {area:F2}");
Console.WriteLine($"Math.Sqrt(16)            = {Math.Sqrt(16)}   ← .NET's own static methods");
// var helper = new MathHelper();   // error CS0712: Cannot create an instance of the static class 'MathHelper'
// MathHelper.Pi = 3;               // error CS0131: The left-hand side of an assignment must be a variable, property or indexer
Console.WriteLine();

// ===== 6.3 Shared state (notes §6.3) =====
Console.WriteLine("--- 6.3 Shared state ---");

Console.WriteLine($"before: User.TotalCreated = {User.TotalCreated}");
var u1 = new User("Alice");
var u2 = new User("Bob");
Console.WriteLine($"after 2 × new User: User.TotalCreated = {User.TotalCreated}");
Console.WriteLine($"u1.Describe() → {u1.Describe()}");
Console.WriteLine($"u2.Name = {u2.Name}   ← each user has its own Name");
// Console.WriteLine(u1.TotalCreated);
//   error CS0176: Member 'User.TotalCreated' cannot be accessed with an instance reference; qualify it with a type name instead

Console.WriteLine("\nDone. Next: Session05.Inheritance");
