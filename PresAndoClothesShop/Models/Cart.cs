using Microsoft.EntityFrameworkCore;
using PresAndoClothesShop.Data;

namespace PresAndoClothesShop.Models
{
    public class Cart
    {
        private readonly ClothesShopContext _context;
        public Cart(ClothesShopContext context)
        {
            _context = context;
        }
        public string Id { get; set; }
        public List<CartItem> CartItems { get; set; }
        public static Cart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<ClothesShopContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new Cart(context) { Id = cartId };
        }

        public List<CartItem> GetAllCartItems()
        {
            return CartItems ??
                (CartItems = _context.CartItems
                .Where(ci => ci.CartId == Id)
                .Include(ci => ci.Product)
                .ToList());
        }
    }
}
