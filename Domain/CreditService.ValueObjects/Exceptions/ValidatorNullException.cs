namespace CreditService.ValueObjects.Exceptions;

public class ValidatorNullException(string paramName)
    : ArgumentNullException(paramName, $"Argument \"{paramName}\" validator is null");

