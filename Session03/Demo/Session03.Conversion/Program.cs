// Session 03 · Demo 2 · Type Conversion  (notes §4)
// Run: dotnet run --project Session03.Conversion

using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 03 · Type Conversion ===\n");

// ===== 4.1 Implicit (notes §4.1) =====
// Automatic when no data can be lost.
Console.WriteLine("--- 4.1 Implicit (automatic, safe) ---");

int x = 100;
long y = x;
double d = x;
Console.WriteLine($"int {x} → long {y} → double {d}");
Console.WriteLine();

// ===== 4.2 Explicit cast (notes §4.2) =====
// You write (type) because data might be lost.
Console.WriteLine("--- 4.2 Explicit cast (you accept the risk) ---");

double pi = 3.14159;
int truncated = (int)pi;                // cuts off, doesn't round
int rounded = (int)Math.Round(2.7);
Console.WriteLine($"(int)3.14159          = {truncated}   ← cut off");
Console.WriteLine($"(int)Math.Round(2.7)  = {rounded}   ← rounded");

long big = 3_000_000_000L;              // too big for int
int wrong = (int)big;
Console.WriteLine($"(int)3_000_000_000L   = {wrong}   ← silently wrong!");

try
{
    int safe = checked((int)big);       // checked → throws instead of wrapping
    Console.WriteLine($"checked((int)big)     = {safe}");
}
catch (OverflowException)
{
    Console.WriteLine("checked((int)big)     → OverflowException ✅ (much better than a wrong number)");
}
Console.WriteLine();

// ===== 4.3 Convert (notes §4.3) =====
Console.WriteLine("--- 4.3 Convert ---");

int n = Convert.ToInt32("42");
bool flag = Convert.ToBoolean("true");
double dd = Convert.ToDouble("3.14", CultureInfo.InvariantCulture);
Console.WriteLine($"Convert.ToInt32(\"42\")     = {n}");
Console.WriteLine($"Convert.ToBoolean(\"true\") = {flag}");
Console.WriteLine($"Convert.ToDouble(\"3.14\")  = {dd}");

// The decimal separator depends on the culture.
Console.WriteLine("\ndouble.Parse(\"3.14\") in different cultures:");
foreach (string cultureName in new[] { "en-US", "de-DE", "ar-EG" })
{
    var culture = new CultureInfo(cultureName);
    try
    {
        double value = double.Parse("3.14", culture);
        Console.WriteLine($"  {cultureName}: {value}");
    }
    catch (FormatException)
    {
        Console.WriteLine($"  {cultureName}: FormatException");
    }
}
double safeParse = double.Parse("3.14", CultureInfo.InvariantCulture);   // same on every PC
Console.WriteLine($"  InvariantCulture: {safeParse}  ← same on every PC ✅");
Console.WriteLine();

// ===== 4.4 Parse vs TryParse (notes §4.4) =====
Console.WriteLine("--- 4.4 Parse vs TryParse ---");

string?[] inputs = { "42", "abc", "12abc", "  7 ", null };   // pretend user input

foreach (string? input in inputs)
{
    string shown = input is null ? "null" : $"\"{input}\"";

    // Parse throws on bad input.
    string parseResult;
    try
    {
        parseResult = int.Parse(input!).ToString();
    }
    catch (FormatException)
    {
        parseResult = "FormatException";
    }
    catch (ArgumentNullException)
    {
        parseResult = "ArgumentNullException";
    }

    // TryParse returns true/false and never throws.
    bool ok = int.TryParse(input, out int number);

    Console.WriteLine($"  {shown,-8} Parse → {parseResult,-22} TryParse → {ok,-5} (number = {number})");
}

Console.WriteLine("Rule: TryParse for anything you didn't create yourself.");

Console.WriteLine("\nDone. Next: Session03.Conditions");
