namespace MottuDesafio.Domain.Exception;

public class BadRequestException : BaseException
{
    public BadRequestException(string message) : base(message, 400)
    
    {

    }

}
