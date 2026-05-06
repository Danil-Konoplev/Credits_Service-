using CreditService.ValueObjects.Base;
using CreditService.ValueObjects.Exceptions;

namespace CreditService.ValueObjects.Validators;

public class FullNameValidator : IValidator<string>
{
    private const int MinLength = 2;
    private const int MaxLength = 150;

    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(FullName));

        if (value.Trim().Length < MinLength)
            throw new ArgumentShortValueException(nameof(FullName), MinLength);

        if (value.Trim().Length > MaxLength)
            throw new ArgumentLongValueException(nameof(FullName), MaxLength);

    }
}
