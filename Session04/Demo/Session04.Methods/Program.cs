// Session 04 · Demo 1 · Methods  (notes §3)
// Run: dotnet run --project Session04.Methods

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 04 · Methods ===\n");

// ===== 3.1 Method structure (notes §3.1) =====
Console.WriteLine("--- 3.1 Structure & return types ---");

int result = Add(3, 4);            // call → 3 and 4 are copied into a and b
Console.WriteLine($"Add(3, 4) = {result}");
PrintLine("PrintLine is void: it does something and returns nothing");
Console.WriteLine();

// ===== 3.2 Expression-bodied (notes §3.2) =====
Console.WriteLine("--- 3.2 Expression-bodied => ---");

Console.WriteLine($"Square(5) = {Square(5)}");
Greet("Alice");
Console.WriteLine();

// ===== 3.3 Overloading (notes §3.3) =====
// Same name, different parameters. Overloads must be in a class (see the bottom of the file).
Console.WriteLine("--- 3.3 Overloading ---");

Console.WriteLine($"Calculator.Add(1, 2)     = {Calculator.Add(1, 2)}      → Add(int, int)");
Console.WriteLine($"Calculator.Add(1.5, 2.5) = {Calculator.Add(1.5, 2.5)}      → Add(double, double)");
Console.WriteLine($"Calculator.Add(1, 2, 3)  = {Calculator.Add(1, 2, 3)}      → Add(int, int, int)");
Console.WriteLine($"Calculator.Add(1, 2.5)   = {Calculator.Add(1, 2.5)}    → Add(double, double): 1 becomes 1.0");

// Local functions (methods in top-level code) can't be overloaded:
//   static int Add(int a, int b) => a + b;
//   static double Add(double a, double b) => a + b;
//   error CS0128: A local variable or function named 'Add' is already defined in this scope
Console.WriteLine();

// ===== 3.4 Optional & named parameters (notes §3.4) =====
Console.WriteLine("--- 3.4 Optional & named ---");

CreateUser("Alice");                       // isAdmin = false, age = 18 (defaults)
CreateUser("Bob", isAdmin: true);          // set isAdmin by name
CreateUser("Carol", age: 25);              // skip isAdmin, set age by name
CreateUser(age: 30, name: "Dave");         // named arguments can be in any order
Console.WriteLine();

// ===== 3.5 ref and out (notes §3.5) =====
Console.WriteLine("--- 3.5 By value, ref, out ---");

int a = 5;
TryToDouble(a);                            // by value: the method gets a copy
Console.WriteLine($"by value : a = {a}   ← unchanged");

int x = 5;
DoubleIt(ref x);                           // ref: the method uses x itself
Console.WriteLine($"ref      : x = {x}  ← changed");

if (TryDivide(10, 2, out double quotient)) // out: the method must set it
{
    Console.WriteLine($"out      : TryDivide(10, 2) → True, quotient = {quotient}");
}
bool ok = TryDivide(10, 0, out double zero);
Console.WriteLine($"out      : TryDivide(10, 0) → {ok}, quotient = {zero}");

// Same pattern as int.TryParse(text, out int value).
bool parsed = int.TryParse("42", out int number);
Console.WriteLine($"int.TryParse(\"42\", out int number) → {parsed}, number = {number}");

// Often clearer: return a tuple instead of using out.
var (min, max) = MinMax([4, 9, 1, 7]);
Console.WriteLine($"tuple    : MinMax([4, 9, 1, 7]) → min = {min}, max = {max}");

Console.WriteLine("\nDone. Next: Session04.Strings");

// ----- Local functions (methods used by the code above) -----
static int Add(int a, int b)
{
    return a + b;
}

static void PrintLine(string message)
{
    Console.WriteLine(message);
}

static int Square(int n) => n * n;

static void Greet(string name) => Console.WriteLine($"Hello, {name}!");

static void CreateUser(string name, bool isAdmin = false, int age = 18)
{
    Console.WriteLine($"{name}, admin: {isAdmin}, age: {age}");
}

static void TryToDouble(int value)
{
    value *= 2;                    // only the copy changes
}

static void DoubleIt(ref int value) => value *= 2;

static bool TryDivide(int a, int b, out double result)
{
    if (b == 0)
    {
        result = 0;                // out must be set on every path
        return false;
    }
    result = (double)a / b;
    return true;
}

static (int Min, int Max) MinMax(int[] values)
{
    int min = values[0], max = values[0];
    foreach (int v in values)
    {
        if (v < min) min = v;
        if (v > max) max = v;
    }
    return (min, max);
}

// ----- A class can hold overloads -----
static class Calculator
{
    public static int Add(int a, int b) => a + b;
    public static double Add(double a, double b) => a + b;
    public static int Add(int a, int b, int c) => a + b + c;
}
