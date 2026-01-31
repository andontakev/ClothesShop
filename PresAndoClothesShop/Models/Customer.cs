using System.ComponentModel.DataAnnotations;

namespace PresAndoClothesShop.Models
{
    public class Customer
    {
        /// <summary>
        /// Уникален идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Име
        /// </summary>
        [Required(ErrorMessage = "Моля попълнете име."), Display(Name = "Име")]
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(ErrorMessage = "Моля попълнете фамилия."), Display(Name = "Фамилия")]
        public string LastName { get; set; }
        /// <summary>
        /// Имейл
        /// </summary>
        [Required(ErrorMessage = "Моля попълнете имейл."), Display(Name = "Имейл")]
        public string Email { get; set; }
        /// <summary>
        /// Телефонен номер
        /// </summary>
        [Required(ErrorMessage = "Моля попълнете телефонен номер."), Display(Name = "Телефонен номер")]
        public string PhoneNumber { get; set; }
    }
}
