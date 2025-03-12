using api.Data;
using Microsoft.AspNetCore.Identity;

namespace MyApp.Data.Seeders;

public static class RoleSeeder
{
    public static void SeedRole(ApplicationDBContext context)
    {
        if (!context.Roles.Any())
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
        context.Roles.AddRange(roles);
        context.SaveChanges();
        }
    }
}