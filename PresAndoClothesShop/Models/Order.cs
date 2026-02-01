using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PresAndoClothesShop.Models
{
    public class Order
    {
        /// <summary>
        /// Уникален идентификатор
        /// </summary>
        [Key, Display(Name = "Номер на поръчката")]
        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<Product> Products { get; set; }
        /// <summary>
        /// Дата на поръчката
        /// </summary>
        [Required, DataType(DataType.Date), Display(Name = "Дата на поръчката")]
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Обща сума
        /// </summary>
        [Display(Name = "Обща сума")]
        public decimal Total { get; set; }
        /// <summary>
        /// Статус на поръчката
        /// </summary>
        [Required, Display(Name = "Статус на поръчката")]
        public string Status { get; set; }
    }
}
