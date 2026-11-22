// Session 05 · Demo 7 · Common Mistakes  (notes §10)
// Run: dotnet run --project Session05.CommonMistakes
// Each mistake: ❌ wrong, then ✅ right. Small classes are at the bottom of the file.

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 05 · Common Mistakes ===\n");

// ----- 1. Public fields with no validation -----
Console.WriteLine("1. Public fields: anyone can break the object");
var bad = new OpenProduct();
bad.Price = -50;
Console.WriteLine($"   ❌ OpenProduct.Price = -50 → accepted: {bad.Price}");
var good = new SafeProduct();
try
{
    good.Price = -50;
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("   ✅ SafeProduct.Price = -50 → ArgumentOutOfRangeException");
}
Console.WriteLine();

// ----- 2. Non-nullable string with no value -----
// ❌ public string Name;
//    warning CS8618: Non-nullable field 'Name' must contain a non-null value when exiting constructor.
Console.WriteLine("2. A string field/property with no starting value");
Console.WriteLine($"   ✅ = \"\", a constructor, or required → \"{new SafeProduct().Name}\"");
Console.WriteLine();

// ----- 3. Copying a reference and expecting a copy -----
Console.WriteLine("3. Thinking b = a copies the object");
var a = new SafeProduct { Name = "Pen" };
var b = a;
b.Name = "Pencil";
Console.WriteLine($"   ❌ b = a; b.Name = \"Pencil\" → a.Name = {a.Name}");
var c = new SafeProduct { Name = a.Name };
c.Name = "Marker";
Console.WriteLine($"   ✅ create a new object → a.Name = {a.Name}, c.Name = {c.Name}");
Console.WriteLine();

// ----- 4. Expecting the default constructor after adding one -----
// ❌ new Person();   error CS7036: There is no argument given that corresponds to the required parameter 'name' of 'Person.Person(string)'
Console.WriteLine("4. new Person() after writing Person(string name)");
Console.WriteLine($"   ✅ pass the arguments: {new Person("Alice").Name}, or add a parameterless constructor too");
Console.WriteLine();

// ----- 5. Storing a value that can be computed -----
Console.WriteLine("5. Storing a computed value in a field");
var stale = new StaleRectangle(4, 6);
stale.Width = 10;
Console.WriteLine($"   ❌ stored Area after Width = 10 → {stale.Area} (stale)");
var fresh = new FreshRectangle { Width = 4, Height = 6 };
fresh.Width = 10;
Console.WriteLine($"   ✅ computed Area after Width = 10 → {fresh.Area}");
Console.WriteLine();

// ----- 6. Mutable public static field -----
Console.WriteLine("6. A public static field anyone can change");
Config.TaxRate = 0;
Console.WriteLine($"   ❌ Config.TaxRate = 0 → every object now uses {Config.TaxRate}");
Console.WriteLine($"   ✅ const or a get-only static property: SafeConfig.TaxRate = {SafeConfig.TaxRate}");
Console.WriteLine();

// ----- 7. Static method using instance data -----
// ❌ public static string Bad() => Name;
//    error CS0120: An object reference is required for the non-static field, method, or property
Console.WriteLine("7. Using instance members inside a static method");
Console.WriteLine("   ✅ make the method an instance method, or pass the object in as a parameter");
Console.WriteLine();

// ----- 8. Forgetting base(...) -----
// ❌ public Dog() { }   when Animal only has Animal(string name)
//    error CS7036: There is no argument given that corresponds to the required parameter 'name' of 'Animal.Animal(string)'
Console.WriteLine("8. Derived constructor without base(...)");
Console.WriteLine($"   ✅ public Dog(string name) : base(name) → {new Dog("Rex").Name}");
Console.WriteLine();

// ----- 9. Same method name without virtual/override -----
Console.WriteLine("9. Re-declaring a method instead of overriding it");
Animal hidden = new Dog("Rex");
Console.WriteLine($"   ❌ hidden (no override)   → {hidden.SoundHidden()}   (warning CS0108, Dog's version ignored)");
Console.WriteLine($"   ✅ virtual + override    → {hidden.Sound()}");
Console.WriteLine();

// ----- 10. Inheriting from more than one class -----
// ❌ class C : A, B { }   error CS1721: Class 'C' cannot have multiple base classes: 'A' and 'B'
Console.WriteLine("10. Two base classes");
Console.WriteLine("   ✅ one base class only (interfaces, Session 06, allow more)");

Console.WriteLine("\nDone. That's all seven demos — now try the Lab!");

// ----- Small classes used above -----
class OpenProduct
{
    public decimal Price;
}

class SafeProduct
{
    public string Name { get; set; } = "";

    public decimal Price
    {
        get;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            field = value;
        }
    }
}

class Person(string name)
{
    public string Name { get; } = name;
}

class StaleRectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double Area;                // set once, never updated

    public StaleRectangle(double width, double height)
    {
        Width = width;
        Height = height;
        Area = width * height;
    }
}

class FreshRectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double Area => Width * Height;
}

static class Config
{
    public static decimal TaxRate = 0.14m;
}

static class SafeConfig
{
    public const decimal TaxRate = 0.14m;
}

class Animal(string name)
{
    public string Name { get; } = name;
    public virtual string Sound() => "...";
    public string SoundHidden() => "...";
}

class Dog(string name) : Animal(name)
{
    public override string Sound() => "Woof";
#pragma warning disable CS0108   // the mistake on purpose: hides Animal.SoundHidden
    public string SoundHidden() => "Woof";
#pragma warning restore CS0108
}
