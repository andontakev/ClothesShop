using System.ComponentModel.DataAnnotations;

namespace PresAndoClothesShop.ViewModel
{
    public class EditRoleViewModel
    {
        /// <summary>
        /// Уникален идентификатор
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Име на ролята
        /// </summary>
        [Display(Name = "Роля")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        public string RoleName { get; set; }
        /// <summary>
        /// Потребители
        /// </summary>
        public List<string> Users { get; set; } = new List<string>();
    }
}
