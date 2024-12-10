using IdentityBase.Data.Contexts;
using IdentityBase.Interfaces;
using IdentityBase.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityBase.Base;

[ApiController]
[Route("api/user")]
public abstract class UserControllerBase<T> where T : IdentityUser
{
    protected readonly UserManager<T> _userManager;
    protected readonly RoleManager<IdentityRole> _roleManager;
    protected readonly SignInManager<T> _signInManager;
    protected readonly ITokenService<T> _tokenService;
    protected readonly UserRoleService<T> _userRoleService;
    protected readonly IdentityContext<T> _identityContext;

    [HttpGet("me")]
    [Authorize]
    public abstract Task<IActionResult> Me();

    [HttpGet("profile/{id}")]
    [Authorize]
    public abstract Task<IActionResult> GetProfile([FromRoute] string id);

    [HttpGet("check")]
    [Authorize]
    public abstract Task<IActionResult> CheckLogin();

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public abstract Task<IActionResult> GetAll();

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public abstract Task<IActionResult> DeleteAll();

    [HttpGet]
    [Route("{username}")]
    [Authorize(Roles = "Admin")]
    public abstract Task<IActionResult> GetByName([FromRoute] string username);

    [HttpDelete]
    [Route("{username}")]
    [Authorize(Roles = "Admin")]
    public abstract Task<IActionResult> DeleteByName([FromRoute] string username);

    [HttpPost("login")]
    public abstract Task<IActionResult> Login<D>([FromBody] D dto);

    [HttpPost("register")]
    public abstract Task<IActionResult> Register<D>([FromBody] D dto);

    [HttpPut]
    [Authorize]
    public abstract Task<IActionResult> UpdateSelf<D>([FromBody] D dto);

    [HttpPut("{userId}")]
    [Authorize(Roles = "Admin")]
    public abstract Task<IActionResult> UpdateUser<D>([FromBody] D dto, [FromRoute] string userId);
}
