
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_20.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppIdentityDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string roleAdmin = "admin";
            string roleEditor = "editor";
            context.Database.EnsureCreated();
            ApplicationUser user = new ApplicationUser()
            {
                UserName = "egemen",
                Email = "mustafaegemenozmen@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString()
            };
           

            if (!context.Users.Any())
            {
                await userManager.CreateAsync(user, "@Password135");

            
             if (!context.Roles.Any())
             {
                if(await roleManager.FindByNameAsync(roleAdmin) == null)
                   
                   await roleManager.CreateAsync(new IdentityRole(roleAdmin)); 
             }
            
            if(await roleManager.FindByNameAsync(roleEditor) == null)
            {
               await roleManager.CreateAsync(new IdentityRole(roleEditor));
            }
                await userManager.AddToRoleAsync(user, roleAdmin);

            }
        }
    }
}
