using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PresAndoClothesShop.Data;

namespace PresAndoClothesShop.Models
{
    public static class UserRoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<DefaultUser>>();
            var context = serviceProvider.GetRequiredService<ClothesShopContext>();

            string[] roleNames = { "Администратор", "Потребител" };
            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var email = "admin@presando.com";
            var password = "Word123!";
            var adminUser = await userManager.FindByEmailAsync(email);
            if (adminUser == null)
            {
                adminUser = new DefaultUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Address = "Admin Street 1",
                    City = "New City 1",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Администратор");
                }
            }

            await EnsureTestDressAsync(context);
        }

        private static async Task EnsureTestDressAsync(ClothesShopContext context)
        {
            var dressCategory = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Dresses");
            if (dressCategory == null)
            {
                dressCategory = new Category { Name = "Dresses" };
                context.Categories.Add(dressCategory);
                await context.SaveChangesAsync();
            }

            var hasDress = await context.Products.AnyAsync(p => p.Name == "Summer Floral Dress");
            if (!hasDress)
            {
                context.Products.Add(new Product
                {
                    Name = "Summer Floral Dress",
                    Description = "Test product dress for cart and checkout flows.",
                    Price = 79.99m,
                    CategoryId = dressCategory.Id,
                    Size = "M",
                    Color = "Blue",
                    ImageUrl = "/assets/dress.jpg"
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
