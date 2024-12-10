using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityBaseModel.Data.Contexts;
public class IdentityContext<T> : IdentityDbContext<T> where T : IdentityUser
{
    public DbSet<T> Users { get; set; }
    public async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        string[] roles = ["User", "Admin"];

        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // ENSURE ROLES
        foreach (var roleName in roles)
        {
            if (!roleManager.Roles.ToList().Exists(r => r.Name == roleName))
            {
                await roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }

        SaveChanges();
    }
}
