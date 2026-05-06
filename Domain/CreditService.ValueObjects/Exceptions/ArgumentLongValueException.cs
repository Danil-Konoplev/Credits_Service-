namespace CreditService.ValueObjects.Exceptions;

public class ArgumentLongValueException(string paramName, int maxLength)
    : ArgumentException($"Argument \"{paramName}\" value is too long. Max length: {maxLength}", paramName)
{
    public int MaxLength => maxLength;
}

