using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresAndoClothesShop.Data;
using PresAndoClothesShop.Models;

namespace PresAndoClothesShop.Controllers
{
    [Authorize]
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
            return RedirectToAction("ListAllRoles");
        }
        public IActionResult RemoveFromCart(int id)
        {
            var selectedProduct = GetProductById(id);
            if (selectedProduct != null)
            {
                _cart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("ListAllRoles");
        }
        public IActionResult IncreaseQuantity(int id)
        {
            var selectedProduct = GetProductById(id);
            if (selectedProduct != null)
            {
                _cart.IncreaseQuantity(selectedProduct);
            }
            return RedirectToAction("ListAllRoles");
        }
        public IActionResult ClearCart()
        {
            _cart.ClearCart();
            return RedirectToAction("ListAllRoles");
        }
        public Product GetProductById(int id)
        { 
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
