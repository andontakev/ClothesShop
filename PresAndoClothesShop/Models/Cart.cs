using Microsoft.EntityFrameworkCore;
using PresAndoClothesShop.Data;

namespace PresAndoClothesShop.Models
{
    /// <summary>Модел за пазарска количка.</summary>
    public class Cart
    {
        private readonly ClothesShopContext _context;

        /// <summary>Инициализира количката.</summary>
        public Cart(ClothesShopContext context)
        {
            _context = context;
        }

        /// <summary>Идентификатор на количката.</summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>Списък с артикули в количката.</summary>
        public virtual List<CartItem> CartItems { get; set; } = new();

        /// <summary>Връща количката от сесията или създава нова.</summary>
        public static Cart GetCart(IServiceProvider service)
        {
            var context = service.GetRequiredService<ClothesShopContext>();
            var httpContext = service.GetRequiredService<IHttpContextAccessor>().HttpContext
                ?? throw new InvalidOperationException("HttpContext is not available.");
            var session = httpContext.Session;

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            EnsureCartExists(context, cartId);

            return new Cart(context) { Id = cartId };
        }

        /// <summary>Гарантира, че количката съществува в базата.</summary>
        private static void EnsureCartExists(ClothesShopContext context, string cartId)
        {
            context.Database.ExecuteSqlInterpolated($@"
            IF NOT EXISTS (SELECT 1 FROM Cart WHERE Id = {cartId})
            BEGIN
                INSERT INTO Cart (Id) VALUES ({cartId})
            END");
        }

        /// <summary>Връща артикул от количката.</summary>
        public CartItem? GetCartItem(Product product)
        {
            return _context.CartItems
                .SingleOrDefault(ci => ci.CartId == Id && ci.ProductId == product.Id);
        }

        /// <summary>Добавя продукт в количката.</summary>
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

        /// <summary>Намалява количеството на продукт.</summary>
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

                _context.SaveChanges();
            }

            return remainingQuantity;
        }

        /// <summary>Увеличава количеството на продукт.</summary>
        public int IncreaseQuantity(Product product)
        {
            var cartItem = GetCartItem(product);
            int newQuantity = 0;

            if (cartItem != null)
            {
                cartItem.Quantity++;
                newQuantity = cartItem.Quantity;
                _context.SaveChanges();
            }

            return newQuantity;
        }

        /// <summary>Премахва продукт от количката.</summary>
        public void RemoveFromCart(Product product)
        {
            var cartItem = GetCartItem(product);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }
        }

        /// <summary>Изчиства количката.</summary>
        public void ClearCart()
        {
            var cartItems = _context.CartItems.Where(ci => ci.CartId == Id);
            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        /// <summary>Връща всички артикули в количката.</summary>
        public List<CartItem> GetAllCartItems()
        {
            return CartItems = _context.CartItems
                .Where(ci => ci.CartId == Id)
                .Include(ci => ci.Product)
                .ToList();
        }

        /// <summary>Изчислява общата стойност на количката.</summary>
        public decimal GetCartTotal()
        {
            return _context.CartItems
                .Where(ci => ci.CartId == Id)
                .Select(ci => (decimal?)(ci.Product.Price * ci.Quantity))
                .Sum() ?? 0m;
        }
    }

}
