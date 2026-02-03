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
        public CartItem GetCartItem(Product product)
        {
            return _context.CartItems
                .SingleOrDefault(ci => ci.CartId == Id && ci.CartId == Id);
        }
        public void AddToCart(Product product, int quantity)
        {
            var cartItem = GetCartItem(product);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Product = product,
                    Quantity = quantity,
                    CartId = Id
                };
                _context.CartItems.Add(cartItem);
            }
            else
            { 
                cartItem.Quantity += quantity;
            }
            _context.SaveChanges();
        }
        public int ReduceQuantity(Product product)
        {
            var cartItem = GetCartItem(product);
            int remainingQuantity = 0;
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    remainingQuantity = cartItem.Quantity;
                }
                else
                {
                    _context.CartItems.Remove(cartItem);
                }
            }
            _context.SaveChanges();
            return remainingQuantity;
        }
        public int IncreaseQuantity(Product product)
        {
            var cartItem = GetCartItem(product);
            int newQuantity = 0;
            if (cartItem != null)
            {
                cartItem.Quantity++;
                newQuantity = cartItem.Quantity;
            }
            _context.SaveChanges();
            return newQuantity;
        }
        public void RemoveFromCart(Product product)
        {
            var cartItem = GetCartItem(product);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
            }
            _context.SaveChanges();
        }
        public void ClearCart()
        {
            var cartItems = _context.CartItems
                .Where(ci => ci.CartId == Id);
            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }
        public List<CartItem> GetAllCartItems()
        {
            return new List<CartItem>(); /* CartItems ??
                (CartItems = _context.CartItems
                .Where(ci => ci.CartId == Id)
                .Include(ci => ci.Product)
                .ToList());*/
        }
        public int GetCartTotal()
        {
            return _context.CartItems
                .Where(ci => ci.CartId == Id)
                .Select(ci => ci.Product.Price * ci.Quantity)
                .Sum();
        }
    }
}
