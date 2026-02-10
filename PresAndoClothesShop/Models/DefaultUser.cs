using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PresAndoClothesShop.Models
{
    public class DefaultUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string FirstName { get; set; }
        [Required]
        [PersonalData]
        public string LastName { get; set; }
        [Required]
        [PersonalData]
        public string Address { get; set; }
        [Required]
        [PersonalData]
        public string City { get; set; }
        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime UserCreationDate { get; set; } = DateTime.Now;
    }
}
