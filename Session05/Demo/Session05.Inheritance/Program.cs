// Session 05 · Demo 5 · Inheritance & base  (notes §7)
// Run: dotnet run --project Session05.Inheritance

using Session05.Inheritance.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 05 · Inheritance & base ===\n");

// ===== 7.2 Derived classes & base(...) (notes §7.2) =====
// The base constructor runs first.
Console.WriteLine("--- 7.2 Constructor order ---");

Console.WriteLine("new Dog(\"Rex\", \"Labrador\"):");
Dog d = new Dog("Rex", "Labrador");
d.Breathe();                       // inherited from Animal
d.Bark();                          // Dog's own
Console.WriteLine($"Breed = {d.Breed}");
Console.WriteLine();

// ===== 7.3 What a derived class gets (notes §7.3) =====
Console.WriteLine("--- 7.3 IS-A ---");

Console.WriteLine("new Cat(\"Tom\"):");
Cat cat = new Cat("Tom");
cat.Breathe();
cat.Meow();

// A Dog IS-A Animal, so an Animal variable can hold a Dog...
Animal pet = d;
pet.Breathe();
// ...but through an Animal variable you only see Animal's members:
// pet.Bark();   // error CS1061: 'Animal' does not contain a definition for 'Bark' ...

// Every class ends up deriving from object.
Console.WriteLine($"d.ToString() → {d.ToString()}   ← inherited from object");
Console.WriteLine($"d is Animal → {d is Animal}, d is object → {d is object}");

Console.WriteLine("\nDone. Next: Session05.Polymorphism");
