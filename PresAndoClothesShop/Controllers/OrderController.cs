using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresAndoClothesShop.Data;
using PresAndoClothesShop.Models;

namespace PresAndoClothesShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ClothesShopContext _context;
        private readonly Cart _cart;
        public OrderController(ClothesShopContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }
        public IActionResult CheckOut()
        {
            return View();
        }

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

        public IActionResult ChechoutComplete(Order order)
        {
            return View(order);
        }
        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges(); // now order.Id populated

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

            _context.Orders.Update(order); // mark total changed, or set order.Total and _context.Entry(order).Property(o=>o.Total).IsModified = true;
            _context.SaveChanges();
        }
    }
}
