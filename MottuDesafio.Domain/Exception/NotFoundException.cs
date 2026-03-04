namespace MottuDesafio.Domain.Exception;

internal class NotFoundException : BaseException
{
    public NotFoundException(string message) : base(message, 404)
    {

    }
}
