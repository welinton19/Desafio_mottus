using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Enum;

namespace MottusTeste;

public class LoginTeste
{
    [Fact]
    public void CriarUser()
    {
        //Arrange
        var user = new User(
            "John Doe",
            System.Text.Encoding.UTF8.GetBytes("senha123"), // PasswordHash como byte[]
            System.Array.Empty<byte>(),                      // PasswordSalt como byte[] (pode ajustar conforme necessário)
            UserRole.Admin
        );
        //Act
        var name = user.Name;
        var role = user.Role;
        var passwordHash = user.PasswordHash;
        //Assert
        var expectedName = "John Doe";
        var expectedRole = UserRole.Admin;
        var expectedPasswordHash = user.PasswordHash;
        Assert.Equal(expectedName, name);
    }
    [Fact]
    public void CriarUserSenhaVazia()
    {
        //Arrange
        var user = new User(
            "Jane Doe",
            System.Array.Empty<byte>(), // PasswordHash como byte[] vazio
            System.Array.Empty<byte>(), // PasswordSalt como byte[] vazio
            UserRole.Admin
        );
        //Act
        var name = user.Name;
        var role = user.Role;
        var passwordHash = user.PasswordHash;
        //Assert
        var expectedName = "Jane Doe";
        var expectedRole = UserRole.Admin;
        var expectedPasswordHash = user.PasswordHash;
        Assert.Equal(expectedName, name);
    }

    [Fact]
    public void CriarUserSenhaNula()
    {
        //Arrange
        var user = new User(
            "Alice Smith",
            null, // PasswordHash como null
            null, // PasswordSalt como null
            UserRole.Admin
        );
        //Act
        var name = user.Name;
        var role = user.Role;
        var passwordHash = user.PasswordHash;
        //Assert
        var expectedName = "Alice Smith";
        var expectedRole = UserRole.Admin;
        var expectedPasswordHash = user.PasswordHash;
        Assert.Equal(expectedName, name);
    }
    [Fact]
    public void CriarUserComRoleUsuario()
    {
        //Arrange
        var user = new User(
            "Bob Johnson",
            System.Text.Encoding.UTF8.GetBytes("senha456"), // PasswordHash como byte[]
            System.Array.Empty<byte>(),                      // PasswordSalt como byte[] (pode ajustar conforme necessário)
            UserRole.Delivery
        );
        //Act
        var name = user.Name;
        var role = user.Role;
        var passwordHash = user.PasswordHash;
        //Assert
        var expectedName = "Bob Johnson";
        var expectedRole = UserRole.Delivery;
        var expectedPasswordHash = user.PasswordHash;
        Assert.Equal(expectedName, name);
    }

    
}
