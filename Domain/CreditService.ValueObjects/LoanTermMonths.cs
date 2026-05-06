using CreditService.ValueObjects.Base;
using CreditService.ValueObjects.Validators;

namespace CreditService.ValueObjects;

public class LoanTermMonths : ValueObject<int>
{
    public LoanTermMonths(int value) : base(new LoanTermMonthsValidator(), value) { }
}
 