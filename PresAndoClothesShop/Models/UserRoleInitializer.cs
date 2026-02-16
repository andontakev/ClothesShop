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

            await EnsureTestProductsAsync(context);
        }

        private static async Task EnsureTestProductsAsync(ClothesShopContext context)
        {
            var dressesCategory = await GetOrCreateCategoryAsync(context, "Рокли");
            var tshirtsCategory = await GetOrCreateCategoryAsync(context, "Тениски");
            var jacketsCategory = await GetOrCreateCategoryAsync(context, "Якета");
            var pantsCategory = await GetOrCreateCategoryAsync(context, "Панталони");

            var oldDress = await context.Products.FirstOrDefaultAsync(p => p.Name == "Summer Floral Dress");
            if (oldDress != null)
            {
                oldDress.Name = "Лятна флорална рокля";
                oldDress.Description = "Елегантна рокля за ежедневно носене и специални поводи.";
                oldDress.Price = 79.99m;
                oldDress.CategoryId = dressesCategory.Id;
                oldDress.Size = "M";
                oldDress.Color = "Син";
                oldDress.ImageUrl = "/assets/dress.jpg";
            }

            await AddProductIfMissingAsync(context, new Product
            {
                Name = "Лятна флорална рокля",
                Description = "Елегантна рокля за ежедневно носене и специални поводи.",
                Price = 79.99m,
                CategoryId = dressesCategory.Id,
                Size = "M",
                Color = "Син",
                ImageUrl = "/assets/dress.jpg"
            });

            await AddProductIfMissingAsync(context, new Product
            {
                Name = "Кожено яке Urban",
                Description = "Класическо кожено яке с модерен силует.",
                Price = 129.90m,
                CategoryId = jacketsCategory.Id,
                Size = "L",
                Color = "Черен",
                ImageUrl = "/assets/leather-jacket.jpg"
            });

            await AddProductIfMissingAsync(context, new Product
            {
                Name = "Бяла тениска Basic",
                Description = "Мека памучна тениска за ежедневен комфорт.",
                Price = 24.50m,
                CategoryId = tshirtsCategory.Id,
                Size = "M",
                Color = "Бял",
                ImageUrl = "/assets/white-tshirt.png"
            });

            await AddProductIfMissingAsync(context, new Product
            {
                Name = "Дънки Slim Fit",
                Description = "Модерни дънки със стеснен силует и висока еластичност.",
                Price = 64.00m,
                CategoryId = pantsCategory.Id,
                Size = "32",
                Color = "Тъмносин",
                ImageUrl = "/assets/arrival-2.jpg"
            });

            await AddProductIfMissingAsync(context, new Product
            {
                Name = "Худи Street Vibe",
                Description = "Топло худи с качулка и минималистичен дизайн.",
                Price = 49.00m,
                CategoryId = tshirtsCategory.Id,
                Size = "L",
                Color = "Сив",
                ImageUrl = "/assets/arrival-1.jpg"
            });

            await context.SaveChangesAsync();
        }

        private static async Task<Category> GetOrCreateCategoryAsync(ClothesShopContext context, string categoryName)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
            if (category != null)
            {
                return category;
            }

            category = new Category { Name = categoryName };
            context.Categories.Add(category);
            await context.SaveChangesAsync();
            return category;
        }

        private static async Task AddProductIfMissingAsync(ClothesShopContext context, Product product)
        {
            var exists = await context.Products.AnyAsync(p => p.Name == product.Name);
            if (!exists)
            {
                context.Products.Add(product);
            }
        }
    }
}
