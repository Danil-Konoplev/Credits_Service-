namespace CreditService.ValueObjects.Exceptions;

public class ArgumentOutOfRangeValueException(string paramName, object value, object min, object max)
    : ArgumentOutOfRangeException(paramName, value, $"Argument \"{paramName}\" = {value} is out of range [{min}; {max}]")
{
    public object Min => min;
    public object Max => max;
}

