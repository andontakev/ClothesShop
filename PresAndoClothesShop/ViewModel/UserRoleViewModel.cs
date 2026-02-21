namespace PresAndoClothesShop.ViewModel
{
    public class UserRoleViewModel
    {
        /// <summary>
        /// Уникален идентификатор
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Име
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Проверка дали потребителят е избран за тази роля
        /// </summary>
        public bool IsSelected { get; set; } 
    }
}
