using CreditService.ValueObjects.Base;
using CreditService.ValueObjects.Validators;

namespace CreditService.ValueObjects;

public class LoanAmount : ValueObject<decimal>
{
    public LoanAmount(decimal value) : base(new LoanAmountValidator(), value) { }
}
 