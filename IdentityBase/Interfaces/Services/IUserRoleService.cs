using Microsoft.AspNetCore.Identity;

namespace IdentityBase.Interfaces.Services;
public interface IUserRoleService<T> where T : IdentityUser
{
    public Task AddToRolesAsync(T user, params string[] names);
    public Task RemoveFromRolesAsync(T user, params string[] names);
    public Task DeleteRolesAsync(params string[] names);
    public Task CreateRolesAsync(params string[] names);
}
