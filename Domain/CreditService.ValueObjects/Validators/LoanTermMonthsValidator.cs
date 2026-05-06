using CreditService.ValueObjects.Base;
using CreditService.ValueObjects.Exceptions;

namespace CreditService.ValueObjects.Validators;

public class LoanTermMonthsValidator : IValidator<int>
{
    private const int MinTerm = 1;
    private const int MaxTerm = 360;

    public void Validate(int value)
    {
        if (value < MinTerm || value > MaxTerm)
            throw new ArgumentOutOfRangeValueException(nameof(LoanTermMonths), value, MinTerm, MaxTerm);
    }
}

