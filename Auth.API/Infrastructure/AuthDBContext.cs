using Auth.API.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Infrastructure
{
    public class AuthDBContext:IdentityDbContext
    {
        public AuthDBContext(DbContextOptions opts):base(opts)
        {
            
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUserRole>().HasData(new ApplicationUserRole[] 
            {
                new ApplicationUserRole()
                {Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
                },
                new ApplicationUserRole()
                {Name = "Host",
                NormalizedName = "HOST"
                },
                new ApplicationUserRole()
                { Name="Guest",
                NormalizedName = "GUEST"
                },
                new ApplicationUserRole()
                { Name="Other", NormalizedName = "OTHER"}
            });
        }
    }
}

