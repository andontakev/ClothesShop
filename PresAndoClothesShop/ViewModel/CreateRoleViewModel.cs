using System.ComponentModel.DataAnnotations;

namespace PresAndoClothesShop.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Роля")]
        public string RoleName { get; set; }
    }
}
