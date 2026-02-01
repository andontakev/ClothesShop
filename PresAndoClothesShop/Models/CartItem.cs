using System.ComponentModel.DataAnnotations;

namespace PresAndoClothesShop.Models
{
    public class CartItem
    {
        /// <summary>
        /// Номер
        /// </summary>
        [Key]
        [Required, Display(Name = "No.")]
        public int Id { get; set; }
        /// <summary>
        /// Номер на количката
        /// </summary>
        public string CartId { get; set; }
        /// <summary>
        /// Номер на продукта
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Продукт
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
