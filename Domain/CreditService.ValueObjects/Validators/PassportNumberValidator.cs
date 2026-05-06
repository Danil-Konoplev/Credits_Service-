using System.Text.RegularExpressions;
using CreditService.ValueObjects.Base;
using CreditService.ValueObjects.Exceptions;

namespace CreditService.ValueObjects.Validators;

public class PassportNumberValidator : IValidator<string>
{
    private static readonly Regex PassportRegex = new(@"^\d{4} \d{6}$", RegexOptions.Compiled);

    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(PassportNumber));

        if (!PassportRegex.IsMatch(value))
            throw new ArgumentException($"Passport \"{value}\" does not match format XXXX XXXXXX", nameof(PassportNumber));
    }
}
 
