using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PresAndoClothesShop.Models;
namespace PresAndoClothesShop.Data

{
    /// <summary>EF Core контекст за магазина.</summary>
    public class ClothesShopContext : IdentityDbContext<DefaultUser>
    {
        /// <summary>Инициализира контекста.</summary>
        public ClothesShopContext(DbContextOptions<ClothesShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>Конфигурира Lazy Loading и SQL Server.</summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer();
        }

        /// <summary>Категории.</summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>Продукти.</summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>Артикули в колички.</summary>
        public DbSet<CartItem> CartItems { get; set; }

        /// <summary>Поръчки.</summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>Артикули в поръчки.</summary>
        public DbSet<OrderItem> OrderItems { get; set; }
    }

}
