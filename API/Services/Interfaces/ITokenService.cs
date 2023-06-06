using API.Domain;

namespace API.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(User user);
    }
}