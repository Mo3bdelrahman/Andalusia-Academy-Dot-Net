// Session 03 · Demo 4 · Loops  (notes §6)
// Run: dotnet run --project Session03.Loops
// Tip: set a breakpoint (F9) inside a loop and step with F10 (notes §8).

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 03 · Loops ===\n");

// ===== 6.1 for (notes §6.1) =====
// for (start; condition; step)
Console.WriteLine("--- 6.1 for ---");

Console.Write("for i = 0..4 : ");
for (int i = 0; i < 5; i++)
{
    Console.Write(i + " ");
}
Console.WriteLine();

Console.Write("countdown    : ");
for (int i = 10; i > 0; i -= 2)
{
    Console.Write(i + " ");
}
Console.WriteLine();

// Nested: the inner loop runs fully for each outer step.
Console.WriteLine("Nested 3x3 multiplication table:");
for (int i = 1; i <= 3; i++)
{
    for (int j = 1; j <= 3; j++)
    {
        Console.Write($"{i}x{j}={i * j,-3} ");
    }
    Console.WriteLine();
}
Console.WriteLine();

// ===== 6.2 while / do-while (notes §6.2) =====
Console.WriteLine("--- 6.2 while / do-while ---");

// while: checks first, may run 0 times.
int count = 0;
Console.Write("while count < 5 : ");
while (count < 5)
{
    Console.Write(count + " ");
    count++;                       // without this the loop never ends
}
Console.WriteLine();

int never = 10;
while (never < 5)
{
    Console.WriteLine("You will never see this");
    never++;
}
Console.WriteLine("while with a false condition ran 0 times");

// do-while: runs first, checks after → at least once. Good for "ask until valid".
// fakeInput stands in for Console.ReadLine().
string[] fakeInput = { "abc", "-2", "7" };
int attempt = 0;
int input;
do
{
    string typed = fakeInput[attempt];
    attempt++;
    Console.WriteLine($"Enter a positive number: {typed}");
    if (int.TryParse(typed, out input) && input > 0)
    {
        break;
    }
    Console.WriteLine("  ✗ not a positive number, try again");
} while (true);
Console.WriteLine($"Thanks, you entered {input} (after {attempt} attempts)");
Console.WriteLine();

// ===== 6.3 foreach (notes §6.3) =====
// Every item in order, no index needed.
Console.WriteLine("--- 6.3 foreach ---");

string[] names = { "Alice", "Bob", "Carol" };
foreach (string name in names)
{
    Console.WriteLine($"Hello, {name}");
}

// Need the index? Use for.
for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine($"names[{i}] = {names[i]}");
}
Console.WriteLine();

// ===== 6.4 break / continue (notes §6.4) =====
Console.WriteLine("--- 6.4 break / continue ---");

Console.Write("Output: ");
for (int i = 0; i < 10; i++)
{
    if (i == 3) continue;          // skip this round
    if (i == 7) break;             // leave the loop
    Console.Write(i + " ");
}
Console.WriteLine();

// break leaves only the inner loop.
Console.WriteLine("break in a nested loop:");
for (int row = 1; row <= 2; row++)
{
    for (int col = 1; col <= 5; col++)
    {
        if (col == 3) break;
        Console.Write($"({row},{col}) ");
    }
    Console.WriteLine();
}
Console.WriteLine();

// ===== Off-by-one (notes §9) =====
Console.WriteLine("--- Off-by-one ---");

int[] values = { 10, 20, 30 };     // valid indexes: 0, 1, 2
try
{
    for (int i = 0; i <= values.Length; i++)   // ❌ <= goes one too far
    {
        Console.Write(values[i] + " ");
    }
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("\n❌ i <= values.Length → IndexOutOfRangeException at i = 3");
}

Console.Write("✅ i <  values.Length → ");
for (int i = 0; i < values.Length; i++)
{
    Console.Write(values[i] + " ");
}
Console.WriteLine();

Console.WriteLine("\nDone. Next: Session03.Arrays");
