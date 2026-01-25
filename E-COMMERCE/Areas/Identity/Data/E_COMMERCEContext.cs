using E_COMMERCE.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_COMMERCE.Data;

public class E_COMMERCEContext : IdentityDbContext<E_COMMERCEUser, IdentityRole, string>
{
    public E_COMMERCEContext(DbContextOptions<E_COMMERCEContext> options)
        : base(options)
    {
    }




    protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);// Customize the ASP.NET Identity model and override the defaults if needed.// For example, you can rename the ASP.NET Identity table names and more.// Add your customizations after calling base.OnModelCreating(builder);
}
