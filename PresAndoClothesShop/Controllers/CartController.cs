using Microsoft.AspNetCore.Mvc;
using PresAndoClothesShop.Models;

namespace PresAndoClothesShop.Controllers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;
        public CartController(Cart cart)
        {
            _cart = cart;
        }
        public IActionResult Index()
        {
            var items = _cart.GetAllCartItems();
            _cart.CartItems = items;
            return View(_cart);
        }
    }
}
