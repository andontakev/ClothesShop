using Microsoft.AspNetCore.Identity;

namespace PresAndoClothesShop.Models
{
    public static class UserRoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        { 
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<DefaultUser>>();

            string[] roleNames = { "Администратор", "Потребител" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            var email = "admin@presando.com";
            var password = "Word123!";
            if (userManager.FindByEmailAsync(email).Result == null)
            {
                var user = new DefaultUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Address = "Admin Street 1",
                    City = "New City 1"
                };
                IdentityResult result = userManager.CreateAsync(user, password).Result;
              
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Администратор").Wait();
                }
            }

            
        }
    }
}
