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
                OrderDate = DateTime.Now
            };
            var expectedTotalPrice = 109.97m;
            Assert.AreEqual(expectedTotalPrice, order.Total);
        }
        [TestMethod]
        public void OrderTest2()
        {
            var order = new PresAndoClothesShop.Models.Order
            {
                Id = 2,
                Total = 59.98m,
                OrderDate = DateTime.Now
            };
            var expectedId = 2;
            Assert.AreEqual(expectedId, order.Id);
        }
        [TestMethod]
        public void OrderTest3()
        {
            var order = new PresAndoClothesShop.Models.Order
            {
                Id = 3,
                Total = 79.99m,
                OrderDate = DateTime.Now
            };
            var expectedOrderDate = DateTime.Now.Date;
            Assert.AreEqual(expectedOrderDate, order.OrderDate.Date);
        }
        [TestMethod]
        public void OrderItemTest1()
        {
            var orderItem = new PresAndoClothesShop.Models.OrderItem
            {
                Id = 1,
                OrderId = 1,
                ProductId = 1,
                Quantity = 2
            };
            var expectedOrderId = 1;
            Assert.AreEqual(expectedOrderId, orderItem.OrderId);
        }
        [TestMethod]
        public void OrderItemTest2()
        {
            var orderItem = new PresAndoClothesShop.Models.OrderItem
            {
                Id = 2,
                OrderId = 1,
                ProductId = 2,
                Quantity = 1
            };
            var expectedProductId = 2;
            Assert.AreEqual(expectedProductId, orderItem.ProductId);
        }
        [TestMethod]
        public void OrderItemTest3()
        {
            var orderItem = new PresAndoClothesShop.Models.OrderItem
            {
                Id = 3,
                OrderId = 2,
                ProductId = 3,
                Quantity = 3
            };
            var expectedQuantity = 3;
            Assert.AreEqual(expectedQuantity, orderItem.Quantity);
        }
        [TestMethod]
        public void OrderItemTest4()
        {
            var orderItem = new PresAndoClothesShop.Models.OrderItem
            {
                Id = 4,
                OrderId = 2,
                ProductId = 4,
                Quantity = 1
            };
            var expectedId = 4;
            Assert.AreEqual(expectedId, orderItem.Id);
        }
        [TestMethod]
        public void OrderItemPriceTest()
        {
            var orderItem = new PresAndoClothesShop.Models.OrderItem
            {
                Id = 30,
                OrderId = 20,
                ProductId = 7,
                Quantity = 2,
                Price = 49.95m
            };
            Assert.AreEqual(49.95m, orderItem.Price);
            Assert.AreEqual(2, orderItem.Quantity);
        }

    }
}
