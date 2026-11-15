// Session 03 · LAB (starter)  (notes §11)
// Run from a terminal (it reads keyboard input): dotnet run --project Session03.Lab
// Stuck? See the Demo solution, especially Session03.Loops and Session03.Arrays.

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 03 Lab ===\n");

// ----- 1. Even or odd -----
// Given: keeps asking until the input is a whole number.
int number;
do
{
    Console.Write("Enter an integer: ");
} while (!int.TryParse(Console.ReadLine(), out number));

// TODO 1: print "42 is even" or "7 is odd".
// HINT: number % 2 != 0 means odd (works for negatives too).
Console.WriteLine("TODO 1: even or odd");


// ----- 2. Multiplication table -----
// TODO 2: print 10 lines like "7 x 3 = 21" with a for loop (i = 1..10).
Console.WriteLine("TODO 2: multiplication table");


// ----- 3. Min and max of 5 numbers -----
int[] values = new int[5];

// TODO 3a: fill 'values' from the user ("Value 1 of 5: ").
// HINT: a for loop, with the do-while + TryParse pattern from step 1 inside.

// TODO 3b: find min and max WITHOUT Array.Sort.
// HINT: start both at values[0], then compare with the rest.
Console.WriteLine("TODO 3: min and max");


// ----- 4. Label the maximum -----
// TODO 4: use a switch expression: < 10 → "Low", < 100 → "Medium", _ → "High".
Console.WriteLine("TODO 4: label for the maximum");


// ----- 5. Clear output -----
// TODO 5: label every line, e.g. "Minimum: 3", "Maximum: 120 (High)".


// ----- BONUS: values in both arrays -----
// TODO BONUS: read a second array, print the values found in both (arrays only).
// HINT: a loop inside a loop. Don't print the same value twice.
Console.WriteLine("TODO BONUS: common values");


Console.WriteLine("\nDone.");
