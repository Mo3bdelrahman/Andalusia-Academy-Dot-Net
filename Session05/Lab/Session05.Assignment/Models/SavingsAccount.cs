namespace Session05.Assignment.Models;

// TODO 4: SavingsAccount IS-A BankAccount
//   - add InterestRate (decimal), e.g. 0.05m for 5%
//   - ApplyInterest(): adds Balance × InterestRate to the balance
//   - override GetAccountType() to return "Savings"
// HINT: _balance is private to BankAccount, so use Deposit(...) or make a protected helper (notes §5.2).
public class SavingsAccount : BankAccount
{
}

// BONUS: PremiumSavingsAccount : SavingsAccount — doubles the interest rate on each
//        ApplyInterest() call and returns "Premium Savings" from GetAccountType().
// HINT: ApplyInterest must be virtual in SavingsAccount to override it here.
