using Microsoft.AspNetCore.Mvc;
using PresAndoClothesShop.Data;
using PresAndoClothesShop.Models;

namespace PresAndoClothesShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ClothesShopContext _context;
        private readonly Cart _cart;
        public CartController(ClothesShopContext context, Cart cart)
        {
            _cart = cart;
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _cart.GetAllCartItems();
            _cart.CartItems = items;
            return View(_cart);
        }
        public IActionResult AddToCart(int id)
        { 
            var selectedProduct = GetProductById(id);
            if (selectedProduct != null)
            {
                _cart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart(int id)
        {
            var selectedProduct = GetProductById(id);
            if (selectedProduct != null)
            {
                _cart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");
        }
        public IActionResult IncreaseQuantity(int id)
        {
            var selectedProduct = GetProductById(id);
            if (selectedProduct != null)
            {
                _cart.IncreaseQuantity(selectedProduct);
            }
            return RedirectToAction("Index");
        }
        public IActionResult ClearCart()
        {
            _cart.ClearCart();
            return RedirectToAction("Index");
        }
        public Product GetProductById(int id)
        { 
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
