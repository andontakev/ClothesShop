using System.ComponentModel.DataAnnotations;

namespace PresAndoClothesShop.Models
{
    public class Category
    {
        /// <summary>
        /// Уникален идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Категория
        /// </summary>
        [Required(ErrorMessage = "Моля попълнете категория.")]
        public string Name { get; set; }

    }
}
