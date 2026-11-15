// Session 03 · Demo 6 · Common Mistakes  (notes §9)
// Run: dotnet run --project Session03.CommonMistakes
// Each mistake: ❌ wrong, then ✅ right.

using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 03 · Common Mistakes ===\n");

// ----- 1. Comparing double with == -----
Console.WriteLine("1. Comparing double with ==");
double total = 0.1 + 0.2;
Console.WriteLine($"   ❌ total == 0.3                 → {total == 0.3}   (total is really {total:R})");
Console.WriteLine($"   ✅ Math.Abs(total - 0.3) < 1e-9 → {Math.Abs(total - 0.3) < 1e-9}");
Console.WriteLine();

// ----- 2. double for money -----
Console.WriteLine("2. Using double for money");
double dBalance = 0;
decimal mBalance = 0;
for (int i = 0; i < 10; i++)
{
    dBalance += 0.10;
    mBalance += 0.10m;
}
Console.WriteLine($"   ❌ double : {dBalance:R}   (should be 1)");
Console.WriteLine($"   ✅ decimal: {mBalance}");
Console.WriteLine();

// ----- 3. int.Parse on user input -----
Console.WriteLine("3. int.Parse on user input");
string userInput = "12abc";
try
{
    int bad = int.Parse(userInput);
    Console.WriteLine($"   parsed {bad}");
}
catch (FormatException)
{
    Console.WriteLine($"   ❌ int.Parse(\"{userInput}\")    → FormatException (program would crash)");
}
if (int.TryParse(userInput, out int good))
{
    Console.WriteLine($"   ✅ parsed {good}");
}
else
{
    Console.WriteLine($"   ✅ int.TryParse(\"{userInput}\") → false, we show a friendly message");
}
Console.WriteLine();

// ----- 4. Parsing decimals without a culture -----
Console.WriteLine("4. Parsing decimals without a culture");
var german = new CultureInfo("de-DE");
Console.WriteLine($"   ❌ double.Parse(\"3.14\") on a German PC → {double.Parse("3.14", german)}");
Console.WriteLine($"   ✅ double.Parse(\"3.14\", InvariantCulture) → {double.Parse("3.14", CultureInfo.InvariantCulture)}");
Console.WriteLine();

// ----- 5. Casting a big long to int -----
Console.WriteLine("5. Casting a big long to int");
long big = 3_000_000_000L;
Console.WriteLine($"   ❌ (int)big          → {(int)big}  (silently wrong)");
try
{
    int checkedValue = checked((int)big);
    Console.WriteLine($"   checked → {checkedValue}");
}
catch (OverflowException)
{
    Console.WriteLine("   ✅ checked((int)big) → OverflowException (you find out)");
}
Console.WriteLine();

// ----- 6. Missing break in a switch -----
// ❌ Doesn't compile in C#:
//   case 1:
//       Console.WriteLine("one");   // no break
//   case 2: ...
//   error CS0163: Control cannot fall through from one case label to another
Console.WriteLine("6. Missing break in a switch statement");
int x = 1;
string word = x switch { 1 => "one", 2 => "two", _ => "other" };
Console.WriteLine($"   ✅ switch expression: {x} → {word}");
Console.WriteLine();

// ----- 7. Off-by-one in a for loop -----
Console.WriteLine("7. Off-by-one in a for loop");
int[] arr = { 10, 20, 30 };
try
{
    for (int i = 0; i <= arr.Length; i++)
    {
        _ = arr[i];
    }
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("   ❌ for (i = 0; i <= arr.Length; i++) → IndexOutOfRangeException");
}
Console.WriteLine("   ✅ for (i = 0; i <  arr.Length; i++)  — or just use foreach");
Console.WriteLine();

// ----- 8. arr[arr.Length] -----
Console.WriteLine("8. Reading arr[arr.Length]");
try
{
    Console.WriteLine(arr[arr.Length]);
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine($"   ❌ arr[arr.Length] (= arr[{arr.Length}]) → IndexOutOfRangeException");
}
Console.WriteLine($"   ✅ last item: arr[arr.Length - 1] = {arr[arr.Length - 1]}, or arr[^1] = {arr[^1]}");
Console.WriteLine();

// ----- 9. Ignoring that ReadLine can return null -----
// ❌ string s = Console.ReadLine();    → warning CS8600
// ✅ string? s = Console.ReadLine();   → TryParse handles null safely
Console.WriteLine("9. Ignoring that ReadLine can return null");
string? maybeNull = null;
Console.WriteLine($"   ✅ int.TryParse(null, out _) → {int.TryParse(maybeNull, out _)} (no crash)");

Console.WriteLine("\nDone. That's all six demos — now try the Lab!");
