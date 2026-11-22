// Session 05 · ASSIGNMENT (starter) · BankAccount Class Hierarchy  (notes §13)
// Run: dotnet run --project Session05.Assignment
// Build BankAccount and SavingsAccount in the Models folder, then use them here.

using Session05.Assignment.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;   // show ✅ ❌ in the Windows console

Console.WriteLine("=== Session 05 Assignment · Bank Accounts ===\n");

// TODO 5a: create a BankAccount and a SavingsAccount, deposit some money, apply interest.
// TODO 5b: store both in a BankAccount[] and print GetAccountType() and Balance for each.
// HINT: foreach (BankAccount account in accounts) { ... }
Console.WriteLine("TODO: create the accounts and print type and balance");

// TODO 6: show that Balance can't be set from outside the class, as a comment:
//   account.Balance = 1_000_000m;   // error CS???? : write the real message the compiler gives you

// TODO 7: show that Withdraw rejects a bad amount (try/catch, print the message).

Console.WriteLine("\nDone.");
