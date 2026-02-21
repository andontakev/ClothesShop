using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PresAndoClothesShop.Data;
using PresAndoClothesShop.Models;

namespace PresAndoClothesShop.Controllers
{

    /// <summary>Контролер за управление на продукти.</summary>
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ClothesShopContext _context;

        /// <summary>Инициализира контролера.</summary>
        public ProductsController(ClothesShopContext context)
        {
            _context = context;
        }

        /// <summary>Показва всички продукти.</summary>
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var clothesShopContext = _context.Products.Include(p => p.Category);
            return View(await clothesShopContext.ToListAsync());
        }

        /// <summary>Показва детайли за продукт.</summary>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>Форма за създаване на продукт.</summary>
        [Authorize(Roles = "Администратор")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        /// <summary>Създава нов продукт.</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,CategoryId,Size,Color,ImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        /// <summary>Форма за редактиране на продукт.</summary>
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        /// <summary>Записва редактиран продукт.</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,CategoryId,Size,Color,ImageUrl")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        /// <summary>Потвърждение за изтриване на продукт.</summary>
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>Изтрива продукт.</summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>Проверява дали продукт съществува.</summary>
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }

}
