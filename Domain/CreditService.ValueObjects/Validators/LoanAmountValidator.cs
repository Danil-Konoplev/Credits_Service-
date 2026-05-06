using CreditService.ValueObjects.Base;
using CreditService.ValueObjects.Exceptions;

namespace CreditService.ValueObjects.Validators;

public class LoanAmountValidator : IValidator<decimal>
{
    private const decimal MinAmount = 10_000m;
    private const decimal MaxAmount = 10_000_000m;

    public void Validate(decimal value)
    {
        if (value < MinAmount || value > MaxAmount)
            throw new ArgumentOutOfRangeValueException(nameof(LoanAmount), value, MinAmount, MaxAmount);

    }
}
