using System.ComponentModel.DataAnnotations;

namespace PresAndoClothesShop.Models
{
    public class Product
    {
        /// <summary>
        /// Уникален идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Продукт
        /// </summary>
        [Required(ErrorMessage = "Моля попълнете име на продукта."), Display(Name = "Продукт")]
        public string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [Required(ErrorMessage = "Моля попълнете описание на продукта."), Display(Name = "Описание")]
        public string Description { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        [Required(ErrorMessage = "Моля попълнете цена на продукта."), Display(Name = "Цена")]
        public decimal Price { get; set; }
        /// <summary>
        /// Категория
        /// </summary>
        [Required(ErrorMessage = "Моля изберете категория."), Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        [Required(ErrorMessage = "Моля попълнете размер на продукта."), Display(Name = "Размер")]
        public string Size { get; set; }
        /// <summary>
        /// Цвят
        /// </summary>
        [Required(ErrorMessage = "Моля попълнете цвят на продукта."), Display(Name = "Цвят")]
        public string Color { get; set; }
        /// <summary>
        /// Снимка
        /// </summary>
        [Required(ErrorMessage = "Моля попълнете URL на изображението на продукта."), Display(Name = "Снимка")]
        public string ImageUrl { get; set; }
    }
}
