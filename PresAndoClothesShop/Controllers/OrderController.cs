using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresAndoClothesShop.Data;
using PresAndoClothesShop.Models;

namespace PresAndoClothesShop.Controllers
{
    /// <summary>Контролер за създаване и обработка на поръчки.</summary>
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ClothesShopContext _context;
        private readonly Cart _cart;

        /// <summary>Инициализира контролера.</summary>
        public OrderController(ClothesShopContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        /// <summary>Страница за финализиране на поръчка.</summary>
        public IActionResult CheckOut()
        {
            return View();
        }

        /// <summary>Обработва финализиране на поръчка.</summary>
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            var cartItems = _cart.GetAllCartItems();
            _cart.CartItems = cartItems;

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Количката е празна, добавете продукти.");
            }

            if (ModelState.IsValid)
            {
                CreateOrder(order);
                _cart.ClearCart();
                return View("CheckoutComplete", order);
            }

            return View(order);
        }

        /// <summary>Показва завършена поръчка.</summary>
        public IActionResult ChechoutComplete(Order order)
        {
            return View(order);
        }

        /// <summary>Създава поръчка и добавя артикули към нея.</summary>
        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges(); 

            var cartItems = _cart.CartItems;
            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.Product.Id,
                    Quantity = item.Quantity,
                    Price = item.Product.Price * item.Quantity
                };
                _context.OrderItems.Add(orderItem);
                order.Total += orderItem.Price;
            }

            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }

}
