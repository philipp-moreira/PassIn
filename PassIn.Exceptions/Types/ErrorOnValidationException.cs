namespace PassIn.Execeptions;

public class ErrorOnValidationException : PassInExeception
{
    public ErrorOnValidationException(string message) : base(message)
    {
    }


    public ErrorOnValidationException(string message, Exception innerException)
    : base(message, innerException)
    {
    }
}