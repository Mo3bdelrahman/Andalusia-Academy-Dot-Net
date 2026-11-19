// Session 04 · Demo 4 · Exception Handling  (notes §6)
// Run: dotnet run --project Session04.ExceptionHandling
// The custom exception is in Exceptions/InsufficientFundsException.cs

using System.Diagnostics;                       // StackTrace
using Session04.ExceptionHandling.Exceptions;   // InsufficientFundsException

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 04 · Exception Handling ===\n");

// ===== 6.1 try / catch / finally (notes §6.1) =====
// fakeInput stands in for Console.ReadLine().
Console.WriteLine("--- 6.1 try / catch / finally ---");

string?[] fakeInput = { "5", "0", "abc", "99999999999" };
foreach (string? input in fakeInput)
{
    Console.Write($"10 / \"{input}\" → ");
    try
    {
        int result = 10 / int.Parse(input!);
        Console.Write(result);
    }
    catch (DivideByZeroException)
    {
        Console.Write("Cannot divide by zero.");
    }
    catch (FormatException)
    {
        Console.Write("Not a number.");
    }
    catch (Exception ex)                        // general: always last
    {
        Console.Write($"Unexpected {ex.GetType().Name}");
    }
    finally
    {
        Console.WriteLine("   [finally ran]");  // runs every time
    }
}

// finally runs even when the try block returns.
Console.WriteLine($"ReturnEarly() returned {ReturnEarly()}");
Console.WriteLine();

// ===== 6.2 How an exception travels (notes §6.2) =====
// Divide throws → Calculate doesn't catch → caught here.
Console.WriteLine("--- 6.2 Up the call stack ---");

try
{
    Calculator.Calculate(10, 0);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Caught in top-level code: {ex.Message}");
    Console.WriteLine($"Path: {Frames(ex)}");
}
Console.WriteLine();

// ===== 6.3 Catch order (notes §6.3) =====
// Specific first, general last. The other way round doesn't compile:
//   catch (Exception) { }
//   catch (FormatException) { }
//   error CS0160: A previous catch clause already catches all exceptions of this or of a super type ('Exception')

// ===== 6.4 Throwing (notes §6.4) =====
Console.WriteLine("--- 6.4 Throwing ---");

try
{
    Calculator.Divide(10, 0);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Message   : {ex.Message}");
    Console.WriteLine($"ParamName : {ex.ParamName}");   // from nameof(b)
}

// .NET 8+: one-line guard helpers.
try
{
    Calculator.DivideWithGuard(10, 0);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"ThrowIfZero → {ex.GetType().Name}, ParamName = {ex.ParamName}");
}
Console.WriteLine();

// ===== 6.5 Re-throwing (notes §6.5) =====
// throw; keeps where it really failed. throw ex; starts the trace again.
Console.WriteLine("--- 6.5 throw; vs throw ex; ---");

try
{
    Calculator.LogAndRethrow();
}
catch (Exception ex)
{
    Console.WriteLine($"throw;     trace: {Frames(ex)}   ✅ Divide is still there");
}

try
{
    Calculator.LogAndThrowEx();
}
catch (Exception ex)
{
    Console.WriteLine($"throw ex;  trace: {Frames(ex)}   ❌ Divide is gone");
}

// Exception filter: catch only when a condition is true.
try
{
    throw new HttpRequestException("Server busy", null, System.Net.HttpStatusCode.ServiceUnavailable);
}
catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
{
    Console.WriteLine($"when filter: caught only for 503 → {ex.Message}");
}
Console.WriteLine();

// ===== 6.6 Custom exceptions (notes §6.6) =====
Console.WriteLine("--- 6.6 Custom exception ---");

decimal balance = 300m;
foreach (decimal amount in new[] { 100m, 500m })
{
    try
    {
        balance = Bank.Withdraw(balance, amount);
        Console.WriteLine($"Withdrew {amount:N2} → balance {balance:N2}");
    }
    catch (InsufficientFundsException ex)
    {
        Console.WriteLine($"Failed: {ex.Message}");
        Console.WriteLine($"Amount: {ex.Amount:N2}");
    }
}
Console.WriteLine();

// ===== 6.7 Exceptions or TryX? (notes §6.7) =====
Console.WriteLine("--- 6.7 Expected failure → TryParse, not try/catch ---");

foreach (string text in new[] { "42", "abc" })
{
    Console.WriteLine(int.TryParse(text, out int n)
        ? $"\"{text}\" → {n}"
        : $"\"{text}\" → not a number (no exception needed)");
}

Console.WriteLine("\nDone. Next: Session04.CommonMistakes");

// ----- Helpers -----
static int ReturnEarly()
{
    try
    {
        return 1;
    }
    finally
    {
        Console.WriteLine("finally ran before ReturnEarly() returned");
    }
}

// The method names in an exception's stack trace, where it failed first.
static string Frames(Exception ex) =>
    string.Join(" → ", new StackTrace(ex).GetFrames().Select(f => f.GetMethod()?.Name));

static class Calculator
{
    public static int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Divisor cannot be zero.", nameof(b));
        }
        return a / b;
    }

    public static int DivideWithGuard(int a, int b)
    {
        ArgumentOutOfRangeException.ThrowIfZero(b);
        return a / b;
    }

    public static int Calculate(int a, int b) => Divide(a, b) + 1;   // no try/catch here

    public static void LogAndRethrow()
    {
        try
        {
            Divide(1, 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Logging: {ex.Message}");
            throw;                               // ✅ keeps the original trace
        }
    }

    public static void LogAndThrowEx()
    {
        try
        {
            Divide(1, 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Logging: {ex.Message}");
#pragma warning disable CA2200   // the analyzer warns about this on purpose
            throw ex;                            // ❌ resets the trace
#pragma warning restore CA2200
        }
    }
}

static class Bank
{
    public static decimal Withdraw(decimal balance, decimal amount)
    {
        if (amount > balance)
        {
            throw new InsufficientFundsException(amount);
        }
        return balance - amount;
    }
}
