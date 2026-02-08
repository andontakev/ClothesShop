using System.ComponentModel.DataAnnotations;

namespace PresAndoClothesShop.ViewModel
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Роля")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; } = new List<string>();
    }
}
