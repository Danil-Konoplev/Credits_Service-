using CreditService.ValueObjects.Base;
using CreditService.ValueObjects.Validators;

namespace CreditService.ValueObjects;

public class PassportNumber : ValueObject<string>
{
    public PassportNumber(string value) : base(new PassportNumberValidator(), value) { }
}
 