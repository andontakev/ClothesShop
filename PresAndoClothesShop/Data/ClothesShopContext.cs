using Microsoft.EntityFrameworkCore;
using PresAndoClothesShop.Models;
namespace PresAndoClothesShop.Data

{
    public class ClothesShopContext : DbContext
    {
        public ClothesShopContext(DbContextOptions<ClothesShopContext> options) : base(options)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; } = default!;
    }
}
