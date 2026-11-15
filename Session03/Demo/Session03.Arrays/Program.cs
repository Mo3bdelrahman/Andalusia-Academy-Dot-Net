// Session 03 · Demo 5 · Arrays  (notes §7)
// Run: dotnet run --project Session03.Arrays
// Fixed size, one type, indexes 0 .. Length - 1.

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 03 · Arrays ===\n");

// ===== 7.1 Declaring & using (notes §7.1) =====
Console.WriteLine("--- 7.1 Declaring & using ---");

// new T[size] fills the array with default values.
int[] scores = new int[5];
bool[] flags = new bool[2];
string?[] words = new string?[2];
Console.WriteLine($"new int[5]     → [{string.Join(", ", scores)}]");
Console.WriteLine($"new bool[2]    → [{string.Join(", ", flags)}]");
Console.WriteLine($"new string?[2] → [{string.Join(", ", words.Select(w => w ?? "null"))}]");

int[] primes = { 2, 3, 5, 7, 11 };                    // short form
string[] names = new string[] { "Alice", "Bob" };     // long form
int[] evens = [2, 4, 6, 8];                           // collection expression (C# 12+)
Console.WriteLine($"primes = [{string.Join(", ", primes)}]");
Console.WriteLine($"names  = [{string.Join(", ", names)}]");
Console.WriteLine($"evens  = [{string.Join(", ", evens)}]");

Console.WriteLine($"primes[0]     = {primes[0]}   ← the FIRST item is index 0");
Console.WriteLine($"primes.Length = {primes.Length}   ← so the last index is 4");
primes[2] = 99;
Console.WriteLine($"after primes[2] = 99 → [{string.Join(", ", primes)}]");

// ^ counts from the end, .. takes a range (end not included).
Console.WriteLine($"primes[^1]    = {primes[^1]}  ← ^1 = last item (same as primes[Length - 1])");
Console.WriteLine($"primes[^2]    = {primes[^2]}   ← second from the end");
int[] middle = primes[1..3];
Console.WriteLine($"primes[1..3]  = [{string.Join(", ", middle)}]  ← indexes 1 and 2");

try
{
    Console.WriteLine(primes[5]);
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("primes[5]     → IndexOutOfRangeException (valid: 0..4)");
}
Console.WriteLine();

// ===== 7.2 Common operations (notes §7.2) =====
Console.WriteLine("--- 7.2 Sort / Reverse / IndexOf ---");

int[] numbers = { 5, 2, 8, 1, 9 };
Console.WriteLine($"start        : [{string.Join(", ", numbers)}]");

Array.Sort(numbers);               // changes the array itself
Console.WriteLine($"Array.Sort   : [{string.Join(", ", numbers)}]");

Array.Reverse(numbers);
Console.WriteLine($"Array.Reverse: [{string.Join(", ", numbers)}]");

int pos = Array.IndexOf(numbers, 5);
int missing = Array.IndexOf(numbers, 42);
Console.WriteLine($"IndexOf(5)   : {pos}");
Console.WriteLine($"IndexOf(42)  : {missing}  ← -1 means not found");

Console.Write("foreach      : ");
foreach (int n in numbers)
{
    Console.Write(n + " ");
}
Console.WriteLine();

int sum = 0;
foreach (int n in numbers)
{
    sum += n;
}
double average = (double)sum / numbers.Length;   // cast first, or the decimals are lost
Console.WriteLine($"sum = {sum}, average = {average}");
Console.WriteLine();

// ===== 7.3 2D arrays (notes §7.3) =====
Console.WriteLine("--- 7.3 2D arrays ---");

int[,] grid = new int[3, 3];       // 3 rows × 3 columns
grid[0, 0] = 1;
grid[1, 2] = 7;                    // row 1, column 2
Console.WriteLine($"grid[1, 2] = {grid[1, 2]}");

int[,] matrix =
{
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};
Console.WriteLine($"matrix[1, 1]        = {matrix[1, 1]}   ← row 1, column 1 (the middle)");
Console.WriteLine($"matrix.GetLength(0) = {matrix.GetLength(0)}   ← number of rows");
Console.WriteLine($"matrix.GetLength(1) = {matrix.GetLength(1)}   ← number of columns");
Console.WriteLine($"matrix.Length       = {matrix.Length}   ← TOTAL items (3 × 3)");

Console.WriteLine("matrix:");
for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write(matrix[row, col] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("\nDone. Next: Session03.CommonMistakes");
