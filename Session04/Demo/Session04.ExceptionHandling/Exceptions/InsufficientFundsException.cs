namespace Session04.ExceptionHandling.Exceptions;

// A custom exception: inherits from Exception and carries extra data (Amount).
public class InsufficientFundsException : Exception
{
    public decimal Amount { get; }

    public InsufficientFundsException(decimal amount)
        : base($"Insufficient funds. Attempted to withdraw {amount:N2} EGP.")
    {
        Amount = amount;
    }
}
