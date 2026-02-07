using System.ComponentModel.DataAnnotations;

namespace PresAndoClothesShop.Models
{
    public class OrderItem
    {
        /// <summary>
        /// Идентификатор на поръчката
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Идентификатор на поръчката
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Поръчка
        /// </summary>
        public virtual Order Order { get; set; }
        /// <summary>
        /// Идентификатор на продукта
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Продукт
        /// </summary>
        public virtual Product Product{ get; set; }
    }
}
