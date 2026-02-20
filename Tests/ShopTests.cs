namespace Tests
{
    [TestClass]
    public class ShopTests
    {
        [TestMethod]
        public void CategoryTest1()
        {
            var category = new PresAndoClothesShop.Models.Category
            {
                Id = 1,
                Name = "Shirts"
            };
            var expectedName = "Shirts";
            Assert.AreEqual(expectedName, category.Name);
        }
        [TestMethod]
        public void CategoryTest2()
        {
            var category = new PresAndoClothesShop.Models.Category
            {
                Id = 2,
                Name = "Pants"
            };
            var expectedId = 2;
            Assert.AreEqual(expectedId, category.Id);
        }
        [TestMethod]
        public void ProductTest1()
        {
            var product = new PresAndoClothesShop.Models.Product
            {
                Id = 1,
                Name = "T-Shirt",
                Price = 19.99m,
                CategoryId = 1
            };
            var expectedPrice = 19.99m;
            Assert.AreEqual(expectedPrice, product.Price);
        }
        [TestMethod]
        public void ProductTest2()
        {
            var product = new PresAndoClothesShop.Models.Product
            {
                Id = 2,
                Name = "Jeans",
                Price = 49.99m,
                CategoryId = 2
            };
            var expectedName = "Jeans";
            Assert.AreEqual(expectedName, product.Name);
        }
        [TestMethod]
        public void ProductTest3()
        {
            var product = new PresAndoClothesShop.Models.Product
            {
                Id = 3,
                Name = "Jacket",
                Price = 89.99m,
                CategoryId = 1
            };
            var expectedCategoryId = 1;
            Assert.AreEqual(expectedCategoryId, product.CategoryId);
        }
        [TestMethod]
        public void ProductTest4()
        {
            var product = new PresAndoClothesShop.Models.Product
            {
                Id = 4,
                Name = "Skirt",
                Price = 39.99m,
                CategoryId = 2
            };
            var expectedId = 4;
            Assert.AreEqual(expectedId, product.Id);
        }
        [TestMethod]
        public void CartItemTest1()
        {
            var cartItem = new PresAndoClothesShop.Models.CartItem
            {
                Id = 1,
                ProductId = 1,
                Quantity = 2
            };
            var expectedQuantity = 2;
            Assert.AreEqual(expectedQuantity, cartItem.Quantity);
        }
        [TestMethod]
        public void CartItemTest2()
        {
            var cartItem = new PresAndoClothesShop.Models.CartItem
            {
                Id = 2,
                ProductId = 2,
                Quantity = 1
            };
            var expectedProductId = 2;
            Assert.AreEqual(expectedProductId, cartItem.ProductId);
        }
        [TestMethod]
        public void CartItemTest3()
        {
            var cartItem = new PresAndoClothesShop.Models.CartItem
            {
                Id = 3,
                ProductId = 3,
                Quantity = 3
            };
            var expectedId = 3;
            Assert.AreEqual(expectedId, cartItem.Id);
        }
        [TestMethod]
        public void OrderTest1()
        {
            var order = new PresAndoClothesShop.Models.Order
            {
                Id = 1,
                Total = 109.97m,
                OrderDate = DateTime.Now,
                Status = "Processing"
            };
            var expectedTotalPrice = 109.97m;
            Assert.AreEqual(expectedTotalPrice, order.Total);
        }
    }
}
