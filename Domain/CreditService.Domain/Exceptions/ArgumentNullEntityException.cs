namespace CreditService.Domain.Exceptions;

public class ArgumentNullEntityException(string paramName)
    : ArgumentNullException(paramName, $"Аргумент \"{paramName}\" не может быть null");
