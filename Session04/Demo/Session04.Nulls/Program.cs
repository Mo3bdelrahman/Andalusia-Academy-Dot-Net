// Session 04 · Demo 3 · Null & Nullable Types  (notes §5)
// Run: dotnet run --project Session04.Nulls

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 04 · Null & Nullable Types ===\n");

// ===== 5.1 Nullable value types (notes §5.1) =====
// int can't be null. int? can.
Console.WriteLine("--- 5.1 int? ---");

int? age = null;
bool? isVerified = null;
Console.WriteLine($"age = {Show(age)}, HasValue = {age.HasValue}");
Console.WriteLine($"isVerified = {Show(isVerified)}");
Console.WriteLine($"age.GetValueOrDefault() = {age.GetValueOrDefault()}");

age = 30;
Console.WriteLine($"age = {age}, HasValue = {age.HasValue}, Value = {age.Value}");

int? missing = null;
try
{
#pragma warning disable CS8629            // the compiler already warns: "Nullable value type may be null"
    int bad = missing.Value;               // ❌ no value to read
#pragma warning restore CS8629
    Console.WriteLine(bad);
}
catch (InvalidOperationException)
{
    Console.WriteLine("missing.Value → InvalidOperationException");
}
// int plain = null;                       // error CS0037: Cannot convert null to 'int'
Console.WriteLine();

// ===== 5.2 Nullable reference types (notes §5.2) =====
Console.WriteLine("--- 5.2 string vs string? ---");

string? maybeName = null;                  // allowed: string? says "might be null"
// string name = null;                     // warning CS8600 with <Nullable>enable</Nullable>
Console.WriteLine($"maybeName = {Show(maybeName)}");
Console.WriteLine();

// ===== 5.3 ?? and ??= (notes §5.3) =====
Console.WriteLine("--- 5.3 ?? and ??= ---");

int? userAge = null;
int display = userAge ?? 0;                // fallback when null
Console.WriteLine($"userAge ?? 0          → {display}");

string? nickname = null;
string shown = nickname ?? "Unknown";
Console.WriteLine($"nickname ?? \"Unknown\" → {shown}");

string? title = null;
title ??= "Untitled";                      // assign only if null
title ??= "Ignored";                       // already set → no change
Console.WriteLine($"title ??= ...         → {title}");
Console.WriteLine();

// ===== 5.4 ?. null-conditional (notes §5.4) =====
Console.WriteLine("--- 5.4 ?. ---");

string? empty = null;
int? length = empty?.Length;               // null instead of a crash
string? upper = empty?.ToUpper();
Console.WriteLine($"empty?.Length    → {Show(length)}");
Console.WriteLine($"empty?.ToUpper() → {Show(upper)}");

try
{
    int crash = empty!.Length;             // ❌ ! hides the warning, not the problem
    Console.WriteLine(crash);
}
catch (NullReferenceException)
{
    Console.WriteLine("empty!.Length    → NullReferenceException");
}

// Chaining: any null in the chain → the whole thing is null → ?? gives 0.
User? noUser = null;
User noAddress = new("Bob", null);
User full = new("Carol", new Address("12345"));

Console.WriteLine($"noUser?.Address?.PostalCode?.Length ?? 0    → {noUser?.Address?.PostalCode?.Length ?? 0}");
Console.WriteLine($"noAddress?.Address?.PostalCode?.Length ?? 0 → {noAddress?.Address?.PostalCode?.Length ?? 0}");
Console.WriteLine($"full?.Address?.PostalCode?.Length ?? 0      → {full?.Address?.PostalCode?.Length ?? 0}");

// C# 14: ?. on the left of = assigns only when not null.
int[]? scores = null;
scores?[0] = 100;                          // scores is null → nothing happens, no crash
Console.WriteLine($"scores?[0] = 100 with scores null → no crash, scores is {Show(scores)}");
Console.WriteLine();

// ===== 5.5 Null checks (notes §5.5) =====
Console.WriteLine("--- 5.5 Null checks ---");

foreach (string? input in new[] { "Alice", null })
{
    if (input is not null)                 // after this check, input is known to be non-null
    {
        Console.WriteLine($"is not null → Length = {input.Length}");
    }
    else
    {
        Console.WriteLine("is null     → skipped");
    }
}

Console.WriteLine("\nDone. Next: Session04.ExceptionHandling");

// Shows "null" instead of an empty string for null values.
static string Show(object? value) => value?.ToString() ?? "null";

// Tiny types for the chaining example (records and classes come in Session 05).
record Address(string? PostalCode);
record User(string Name, Address? Address);
