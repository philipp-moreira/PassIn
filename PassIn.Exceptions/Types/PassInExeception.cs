namespace PassIn.Execeptions;

public class PassInExeception : SystemException
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