namespace CreditService.ValueObjects.Exceptions;

public class ArgumentShortValueException(string paramName, int minLength)
    : ArgumentException($"Argument \"{paramName}\" value is too short. Min length: {minLength}", paramName)
{
    public int MinLength => minLength;
}

