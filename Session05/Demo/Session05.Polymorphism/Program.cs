// Session 05 · Demo 6 · virtual & override  (notes §8)
// Run: dotnet run --project Session05.Polymorphism

using Session05.Polymorphism.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 05 · virtual & override ===\n");

// ===== 8.2 Polymorphism in action (notes §8.2) =====
// The variable type is Shape; the real object decides which Area() runs.
Console.WriteLine("--- 8.2 Polymorphism ---");

Shape[] shapes =
{
    new Circle(5),
    new Rectangle(4, 6),
    new Square(3),
    new Shape()
};

foreach (Shape s in shapes)
{
    Console.WriteLine($"Area: {s.Area(),6:F2}   ({s.GetType().Name})");
}
Console.WriteLine();

// ===== 8.3 Calling the base version (notes §8.3) =====
Console.WriteLine("--- 8.3 base.Describe() ---");

foreach (Shape s in shapes)
{
    Console.WriteLine(s.Describe());
}
Console.WriteLine();

// ===== 8.4 override vs hiding with new (notes §8.4) =====
Console.WriteLine("--- 8.4 override vs new ---");

Speaker asSpeaker = new Robot();   // a Robot in a Speaker variable
Robot asRobot = new Robot();
Console.WriteLine($"asSpeaker.Speak() → {asSpeaker.Speak()}   ← override: the object decides ✅");
Console.WriteLine($"asSpeaker.Greet() → {asSpeaker.Greet()}   ← new: the variable type decides ⚠️");
Console.WriteLine($"asRobot.Greet()   → {asRobot.Greet()}");
// Overriding a method that isn't virtual:
//   error CS0506: 'Robot.Greet()': cannot override inherited member 'Speaker.Greet()' because it is not marked virtual, abstract, or override
Console.WriteLine();

// ===== 8.5 sealed & ToString() (notes §8.5) =====
Console.WriteLine("--- 8.5 sealed & ToString ---");

var square = new Square(3);
Console.WriteLine($"square.ToString()  → {square}            ← overridden");
Console.WriteLine($"circle.ToString()  → {new Circle(1)}   ← not overridden: the type name");

Console.WriteLine("\nDone. Next: Session05.CommonMistakes");
