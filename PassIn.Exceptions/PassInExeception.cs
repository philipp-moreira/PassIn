namespace PassIn.Execeptions;

public class PassInExeception : Exception
{
    public PassInExeception(string message)
        : base(message)
    {
    }

    public PassInExeception(string message, Exception innerException)
    : base(message, innerException)
    {
    }
}