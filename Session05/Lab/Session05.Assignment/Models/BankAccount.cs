namespace Session05.Assignment.Models;

// TODO 1: encapsulation (notes §5)
//   - a private decimal _balance field
//   - a read-only Balance property (callers can read it, never set it)
//   - an Owner string
// HINT: public decimal Balance => _balance;
//
// TODO 2: Deposit(decimal amount) and Withdraw(decimal amount) that validate their arguments
// HINT: amount must be > 0, and Withdraw can't take more than the balance (throw, notes Session 04 §6.4).
//
// TODO 3: public virtual string GetAccountType() that returns "Standard"
public class BankAccount
{
}
