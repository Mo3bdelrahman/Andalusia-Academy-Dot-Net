// Session 05 · Demo 1 · Classes & Objects  (notes §3)
// Run: dotnet run --project Session05.ClassesObjects
// The classes are in the Models folder.

using Session05.ClassesObjects.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 05 · Classes & Objects ===\n");

// ===== 3.3 Creating objects (notes §3.3) =====
Console.WriteLine("--- 3.3 new ---");

Car car1 = new Car();              // a new object on the heap
car1.Brand = "Toyota";
car1.Year = 2022;
car1.StartEngine();                // Toyota engine started.

Car empty = new Car();             // fields start with default values
Console.WriteLine($"new Car() → Brand = \"{empty.Brand}\", Year = {empty.Year}");
Console.WriteLine();

// ===== 3.4 Object initializer (notes §3.4) =====
Console.WriteLine("--- 3.4 Object initializer ---");

Car car2 = new Car
{
    Brand = "BMW",
    Year = 2024
};
car2.StartEngine();                // BMW engine started.

Car car3 = new() { Brand = "Kia", Year = 2023 };   // target-typed new (C# 9)
car3.StartEngine();

Book book = new() { Title = "Clean Code", Pages = 464 };
Console.WriteLine($"Book: {book.Title}, {book.Pages} pages");
// Book noTitle = new Book();
// error CS9035: Required member 'Book.Title' must be set in the object initializer or attribute constructor.
Console.WriteLine();

// ===== 3.5 Each object has its own data (notes §3.5) =====
Console.WriteLine("--- 3.5 Instances are independent ---");

car1.Year = 2000;
Console.WriteLine($"car1.Year = {car1.Year}, car2.Year = {car2.Year}   ← only car1 changed");

// A class is a reference type: copying the variable copies the reference.
Car sameCar = car1;
sameCar.Brand = "Lexus";
Console.WriteLine($"after sameCar.Brand = \"Lexus\": car1.Brand = {car1.Brand}   ← same object");

// A variable that points to no object is null.
Car? noCar = null;
try
{
    noCar!.StartEngine();
}
catch (NullReferenceException)
{
    Console.WriteLine("noCar.StartEngine() with noCar = null → NullReferenceException");
}

Console.WriteLine("\nDone. Next: Session05.Constructors");
