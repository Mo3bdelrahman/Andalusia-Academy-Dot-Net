// Session 04 · LAB (starter) · Safe Calculator  (notes §10)
// Run from a terminal (it reads keyboard input): dotnet run --project Session04.Lab
// Stuck? See the Demo solution, especially Session04.ExceptionHandling.

using System.Globalization;           // CultureInfo.InvariantCulture for parsing numbers
using System.Text;                    // StringBuilder
using Session04.Lab.Exceptions;       // InvalidExpressionException

Console.OutputEncoding = Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Safe Calculator ===");
Console.WriteLine("Type an expression like 10 / 2, or 'exit' to quit.\n");

var summary = new StringBuilder();    // TODO 5: add one line per calculation

// Given: read lines until the input ends.
while (true)
{
    Console.Write("> ");
    string? line = Console.ReadLine();
    if (line is null) break;          // input ended (Ctrl+Z on Windows, Ctrl+D on macOS/Linux)

    // TODO 4a: if line is "exit" (any case, ignore spaces) → leave the loop.
    // TODO BONUS: if line is "history" → print the summary so far, then continue.

    // TODO 4b: put this call inside try/catch, then print:
    //   a number → e.g. "10 / 2 = 5"
    //   null     → "Invalid operation"
    //   InvalidExpressionException → its message
    // The app must never crash, whatever the user types.
    double? result = SafeCalculate(line);
    Console.WriteLine("TODO 4: print the result");
}

// TODO 5: print the summary of all calculations.
Console.WriteLine("Bye!");

// Returns the result, or null when the operation is invalid (e.g. dividing by zero).
static double? SafeCalculate(string expression)
{
    // TODO 1: split "10 / 2" into 3 parts: number, operator, number.
    // HINT: expression.Split(' ', StringSplitOptions.RemoveEmptyEntries)

    // TODO 2: parse both numbers, then apply + - * / with a switch expression.
    // HINT: double.TryParse(text, CultureInfo.InvariantCulture, out double a)
    // HINT: 10.0 / 0 doesn't throw, it gives ∞. Check the divisor and return null.

    // TODO 3: when the format is wrong, throw new InvalidExpressionException(expression);
    //         (finish the class in Exceptions/InvalidExpressionException.cs first)

    return null;
}
