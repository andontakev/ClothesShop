using System.ComponentModel.DataAnnotations;

namespace PresAndoClothesShop.ViewModel
{
    public class CreateRoleViewModel
    {
        /// <summary>
        /// Име на ролята
        /// </summary>
        [Required]
        [Display(Name = "Роля")]
        public string RoleName { get; set; }
    }
}
