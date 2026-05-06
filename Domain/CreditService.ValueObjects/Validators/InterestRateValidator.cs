using CreditService.ValueObjects.Base;
using CreditService.ValueObjects.Exceptions;

namespace CreditService.ValueObjects.Validators;

public class InterestRateValidator : IValidator<decimal>
{
    private const decimal MinRate = 0.1m;
    private const decimal MaxRate = 100m;

    public void Validate(decimal value)
    {
        if (value < MinRate || value > MaxRate)
            throw new ArgumentOutOfRangeValueException(nameof(InterestRate), value, MinRate, MaxRate);
    }
}

