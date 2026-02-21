using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresAndoClothesShop.Data;
using PresAndoClothesShop.Models;

namespace PresAndoClothesShop.Controllers
{
    /// <summary>Контролер за управление на количката.</summary>
    [Authorize]
    public class CartController : Controller
    {
        private readonly ClothesShopContext _context;
        private readonly Cart _cart;

        /// <summary>Инициализира контролера.</summary>
        public CartController(ClothesShopContext context, Cart cart)
        {
            _cart = cart;
            _context = context;
        }

        /// <summary>Показва съдържанието на количката.</summary>
        public IActionResult Index()
        {
            _cart.CartItems = _cart.GetAllCartItems();
            return View(_cart);
        }

        /// <summary>Добавя продукт в количката.</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int id, string? returnUrl = null)
        {
            var selectedProduct = await GetProductById(id);
            if (selectedProduct == null)
            {
                return NotFound();
            }

            _cart.AddToCart(selectedProduct, 1);
            return RedirectToLocal(returnUrl);
        }

        /// <summary>Премахва продукт от количката.</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var selectedProduct = await GetProductById(id);
            if (selectedProduct == null)
            {
                return NotFound();
            }

            _cart.RemoveFromCart(selectedProduct);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>Увеличава количеството на продукт.</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IncreaseQuantity(int id)
        {
            var selectedProduct = await GetProductById(id);
            if (selectedProduct == null)
            {
                return NotFound();
            }

            _cart.IncreaseQuantity(selectedProduct);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>Намалява количеството на продукт.</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DecreaseQuantity(int id)
        {
            var selectedProduct = await GetProductById(id);
            if (selectedProduct == null)
            {
                return NotFound();
            }

            _cart.ReduceQuantity(selectedProduct);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>Изчиства количката.</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClearCart()
        {
            _cart.ClearCart();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>Връща продукт по Id.</summary>
        private async Task<Product?> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>Пренасочва към локален URL или към Index.</summary>
        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(Index));
        }
    }

}
