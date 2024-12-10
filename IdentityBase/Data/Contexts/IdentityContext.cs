using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityBase.Data.Contexts;
public class IdentityContext<T> : IdentityDbContext<T> where T : IdentityUser
{
    public DbSet<T> Users { get; set; }
}
