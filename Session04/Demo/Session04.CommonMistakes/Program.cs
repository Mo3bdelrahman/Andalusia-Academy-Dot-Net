// Session 04 · Demo 5 · Common Mistakes  (notes §8)
// Run: dotnet run --project Session04.CommonMistakes
// Each mistake: ❌ wrong, then ✅ right.

using System.Text;

Console.OutputEncoding = Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 04 · Common Mistakes ===\n");

// ----- 1. Overloading local functions -----
// ❌ static int Add(int a, int b) ...  +  static double Add(double a, double b) ...
//    error CS0128: A local variable or function named 'Add' is already defined in this scope
Console.WriteLine("1. Overloading methods in top-level code");
Console.WriteLine($"   ✅ put overloads in a class: Calc.Add(1, 2) = {Calc.Add(1, 2)}, Calc.Add(1.5, 2.5) = {Calc.Add(1.5, 2.5)}");
Console.WriteLine();

// ----- 2. Ignoring a string method's result -----
Console.WriteLine("2. Ignoring the result of Trim()");
string s = "  hi  ";
s.Trim();
Console.WriteLine($"   ❌ s.Trim();     → [{s}]");
s = s.Trim();
Console.WriteLine($"   ✅ s = s.Trim(); → [{s}]");
Console.WriteLine();

// ----- 3. Guessing Substring positions -----
Console.WriteLine("3. Guessing Substring positions");
string text = "  Hello, World!  ";
Console.WriteLine($"   ❌ text.Substring(7, 5)                    → [{text.Substring(7, 5)}]");
Console.WriteLine($"   ✅ text.Substring(text.IndexOf(\"World\"), 5) → [{text.Substring(text.IndexOf("World"), 5)}]");
Console.WriteLine();

// ----- 4. Case-insensitive compare with == -----
Console.WriteLine("4. Comparing case-insensitively with ==");
Console.WriteLine($"   ❌ \"admin\" == \"ADMIN\"                  → {"admin" == "ADMIN"}");
Console.WriteLine($"   ✅ string.Equals(..., OrdinalIgnoreCase) →{string.Equals("admin", "ADMIN", StringComparison.OrdinalIgnoreCase)}");
Console.WriteLine();

// ----- 5. += in a loop -----
// (and forgetting using System.Text; → error CS0246: 'StringBuilder' could not be found)
Console.WriteLine("5. Building a string with += in a loop");
var sb = new StringBuilder();
for (int i = 1; i <= 5; i++)
{
    sb.Append(i).Append(' ');
}
Console.WriteLine($"   ✅ StringBuilder → {sb.ToString().TrimEnd()}");
Console.WriteLine();

// ----- 6. Calling a member on null -----
Console.WriteLine("6. Calling a member on null");
string? name = null;
try
{
    Console.WriteLine(name!.Length);
}
catch (NullReferenceException)
{
    Console.WriteLine("   ❌ name!.Length       → NullReferenceException (! only hid the warning)");
}
Console.WriteLine($"   ✅ name?.Length ?? 0  → {name?.Length ?? 0}");
Console.WriteLine();

// ----- 7. Empty catch -----
Console.WriteLine("7. Swallowing exceptions with an empty catch");
int value = 0;
try
{
    value = int.Parse("abc");
}
catch
{
    // ❌ nothing here: the error disappears and value is silently 0
}
Console.WriteLine($"   ❌ catch {{ }} → value = {value}, and nobody knows why");
Console.WriteLine("   ✅ catch the specific exception and handle or log it, or don't catch at all");
Console.WriteLine();

// ----- 8. catch (Exception) first -----
// ❌ catch (Exception) { }  catch (FormatException) { }
//    error CS0160: A previous catch clause already catches all exceptions of this or of a super type
Console.WriteLine("8. General catch before specific ones");
Console.WriteLine("   ✅ specific catches first, catch (Exception) last (or the code doesn't compile)");
Console.WriteLine();

// ----- 9. throw ex; -----
Console.WriteLine("9. Re-throwing with throw ex;");
Console.WriteLine("   ✅ use throw; — see Session04.ExceptionHandling §6.5 for the stack traces");
Console.WriteLine();

// ----- 10. Expecting double / 0 to throw -----
Console.WriteLine("10. Expecting division by zero to throw for double");
double d = 10.0 / 0;
Console.WriteLine($"   ❌ 10.0 / 0 = {d} (no exception! only int / 0 throws)");
Console.WriteLine($"   ✅ check the divisor first, or double.IsInfinity(d) → {double.IsInfinity(d)}");
Console.WriteLine();

// ----- 11. Using exceptions for normal input -----
Console.WriteLine("11. try/catch around int.Parse for user input");
Console.WriteLine($"   ✅ int.TryParse(\"12abc\", out _) → {int.TryParse("12abc", out _)} (no exception needed)");

Console.WriteLine("\nDone. That's all five demos — now try the Lab!");

static class Calc
{
    public static int Add(int a, int b) => a + b;
    public static double Add(double a, double b) => a + b;
}
