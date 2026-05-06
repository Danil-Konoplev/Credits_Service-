using CreditService.ValueObjects.Base;
using CreditService.ValueObjects.Validators;

namespace CreditService.ValueObjects;

public class InterestRate : ValueObject<decimal>
{
    public InterestRate(decimal value) : base(new InterestRateValidator(), value) { }
}
 