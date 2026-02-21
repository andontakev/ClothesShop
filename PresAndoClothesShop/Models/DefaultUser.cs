using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PresAndoClothesShop.Models
{
    public class DefaultUser : IdentityUser
    {
        /// <summary>Име на потребителя.</summary>
        [Required]
        [PersonalData]
        public string FirstName { get; set; }

        /// <summary>Фамилия на потребителя.</summary>
        [Required]
        [PersonalData]
        public string LastName { get; set; }

        /// <summary>Адрес на потребителя.</summary>
        [Required]
        [PersonalData]
        public string Address { get; set; }

        /// <summary>Град на потребителя.</summary>
        [Required]
        [PersonalData]
        public string City { get; set; }

        /// <summary>Дата на създаване на профила.</summary>
        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime UserCreationDate { get; set; } = DateTime.Now;

    }
}
