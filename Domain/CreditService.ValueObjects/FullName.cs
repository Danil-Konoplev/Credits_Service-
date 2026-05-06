using CreditService.ValueObjects.Base;
using CreditService.ValueObjects.Validators;

namespace CreditService.ValueObjects;

public class FullName : ValueObject<string>
{
    public FullName(string value) : base(new FullNameValidator(), value) { }
}

