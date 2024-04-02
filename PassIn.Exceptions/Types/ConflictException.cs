namespace PassIn.Execeptions;

public class ConflictException : PassInExeception
{
    public ConflictException(string message) : base(message)
    {
    }


    public ConflictException(string message, Exception innerException)
    : base(message, innerException)
    {
    }
}