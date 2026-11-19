// Session 04 · Demo 2 · Strings & StringBuilder  (notes §4)
// Run: dotnet run --project Session04.Strings

using System.Diagnostics;   // Stopwatch
using System.Text;          // StringBuilder (not added automatically)

Console.OutputEncoding = Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 04 · Strings & StringBuilder ===\n");

// ===== 4.1 Immutability (notes §4.1) =====
// String methods return a NEW string. The original never changes.
Console.WriteLine("--- 4.1 Immutability ---");

string name = "  Alice  ";
name.Trim();                                   // result thrown away
Console.WriteLine($"after name.Trim();        → [{name}]   ❌ unchanged");
name = name.Trim();                            // keep the result
Console.WriteLine($"after name = name.Trim(); → [{name}]   ✅");
Console.WriteLine();

// ===== 4.2 Common methods (notes §4.2) =====
Console.WriteLine("--- 4.2 Common methods ---");

string s = "  Hello, World!  ";
Console.WriteLine($"s                        = [{s}]");
Console.WriteLine($"s.Length                 = {s.Length}");
Console.WriteLine($"s.Trim()                 = [{s.Trim()}]");
Console.WriteLine($"s.ToUpper()              = [{s.ToUpper()}]");
Console.WriteLine($"s.Contains(\"World\")      = {s.Contains("World")}");
Console.WriteLine($"s.StartsWith(\"  Hello\")  = {s.StartsWith("  Hello")}");
Console.WriteLine($"s.Replace(\"World\", \"C#\") = [{s.Replace("World", "C#")}]");
Console.WriteLine($"s.IndexOf(\"World\")       = {s.IndexOf("World")}");
Console.WriteLine($"s.Substring(9, 5)        = [{s.Substring(9, 5)}]   ← start at index 9, take 5");
Console.WriteLine($"s.Substring(7, 5)        = [{s.Substring(7, 5)}]   ← the deck's version: wrong start");
Console.WriteLine($"s.Split(',')             = [{string.Join(" | ", s.Split(','))}]");
Console.WriteLine($"string.Join(\", \", ...)   = {string.Join(", ", new[] { "a", "b", "c" })}");

// Extras
Console.WriteLine($"s.Split(',', TrimEntries) = [{string.Join(" | ", s.Split(',', StringSplitOptions.TrimEntries))}]");
Console.WriteLine($"string.IsNullOrWhiteSpace(\"   \") = {string.IsNullOrWhiteSpace("   ")}");
string word = "World";
Console.WriteLine($"word[0] = {word[0]}, word[^1] = {word[^1]}, word[1..3] = {word[1..3]}");
Console.WriteLine();

// ===== 4.3 Comparing (notes §4.3) =====
Console.WriteLine("--- 4.3 Comparing ---");

string a = "hello";
string b = "HELLO";
Console.WriteLine($"a == b                                  → {a == b}");
Console.WriteLine($"string.Equals(a, b, OrdinalIgnoreCase)  → {string.Equals(a, b, StringComparison.OrdinalIgnoreCase)}");
Console.WriteLine($"\"Hello World\".Contains(\"world\")         → {"Hello World".Contains("world")}");
Console.WriteLine($"... Contains(\"world\", OrdinalIgnoreCase) → {"Hello World".Contains("world", StringComparison.OrdinalIgnoreCase)}");
Console.WriteLine();

// ===== 4.4 StringBuilder (notes §4.4) =====
Console.WriteLine("--- 4.4 StringBuilder ---");

var sb = new StringBuilder();
for (int i = 1; i <= 100; i++)
{
    sb.Append(i);
    if (i < 100) sb.Append(", ");
}
string list = sb.ToString();
Console.WriteLine($"1..100 → {list[..19]}, ..., {list[^11..]}  (Length {list.Length})");

// AppendLine adds a new line after each item.
var report = new StringBuilder();
report.AppendLine("Report");
report.AppendLine($"Items: {3}");
report.Append("Total: ").Append(45.5m).AppendLine();
Console.Write(report.ToString());

// += in a loop vs StringBuilder (times differ on every PC).
const int count = 20_000;
var timer = Stopwatch.StartNew();
string slow = "";
for (int i = 0; i < count; i++)
{
    slow += "x";                   // a NEW string every time
}
long plusMs = timer.ElapsedMilliseconds;

timer.Restart();
var fast = new StringBuilder();
for (int i = 0; i < count; i++)
{
    fast.Append('x');              // one buffer that grows
}
string fastText = fast.ToString();
long sbMs = timer.ElapsedMilliseconds;

Console.WriteLine($"{count:N0} × +=     : {plusMs} ms ({slow.Length:N0} chars)");
Console.WriteLine($"{count:N0} × Append : {sbMs} ms ({fastText.Length:N0} chars)");

Console.WriteLine("\nDone. Next: Session04.Nulls");
