using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityBaseModel.Base;

[Route("api/roles")]
[ApiController]
public abstract class RoleControllerBase<T> where T : IdentityUser
{
    private readonly UserManager<T> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("{username}")]
    public abstract Task<IActionResult> GetRoles([FromRoute] string username);

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public abstract Task<IActionResult> UpdateToRoles<D>([FromBody] D dto);

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public abstract Task<IActionResult> CreateRoles<D>([FromBody] D roles);

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public abstract Task<IActionResult> DeleteRoles<D>([FromBody] D role);
}
