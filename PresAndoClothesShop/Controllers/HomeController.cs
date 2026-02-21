using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PresAndoClothesShop.Models;

namespace PresAndoClothesShop.Controllers
{
    /// <summary>Основен контролер на приложението.</summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>Инициализира контролера.</summary>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>Начална страница.</summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>Страница за поверителност.</summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>Показва страница за грешки.</summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
