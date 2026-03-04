namespace MottuDesafio.Domain.Exception;

internal class UnauthorizedException : BaseException
{
    public UnauthorizedException(string message) : base(message, 401)
    { }
}
