namespace CreditService.ValueObjects.Exceptions;

public class ArgumentNullOrWhiteSpaceException(string paramName)
    : ArgumentException($"Argument \"{paramName}\" value is null or whitespace", paramName);

