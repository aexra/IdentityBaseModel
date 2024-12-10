using Microsoft.AspNetCore.Identity;

namespace IdentityBase.Interfaces.Services;
public interface ITokenService<T> where T : IdentityUser
{
    public Task<string> CreateToken(T user);
}

