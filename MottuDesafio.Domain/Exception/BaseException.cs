namespace MottuDesafio.Domain.Exception;

public class BaseException : System.Exception
{
    public int StatusCode { get; }

    protected BaseException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}
