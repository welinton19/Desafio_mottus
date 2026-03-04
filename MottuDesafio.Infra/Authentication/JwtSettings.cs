namespace MottuDesafio.InfraData.Authentication;

public class JwtSettings
{
    public string SecretKey { get; set; }
    public string Password { get; set; }
    public bool Encrypt { get; set; }
    public int ExpireMinutes { get; set; } = 60;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;

}
