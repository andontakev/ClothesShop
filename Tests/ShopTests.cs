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
        [TestMethod]
        public void CartItemCartIdTest()
        {
            var cartItem = new PresAndoClothesShop.Models.CartItem
            {
                Id = 40,
                CartId = "cart-123",
                ProductId = 7,
                Quantity = 1
            };
            Assert.AreEqual("cart-123", cartItem.CartId);
            Assert.AreEqual(1, cartItem.Quantity);
        }
        [TestMethod]
        public void ProductCategoryTest()
        {
            var category = new PresAndoClothesShop.Models.Category
            {
                Id = 1,
                Name = "Shirts"
            };
            var product = new PresAndoClothesShop.Models.Product
            {
                Id = 1,
                Name = "T-Shirt",
                Price = 19.99m,
                CategoryId = category.Id
            };
            Assert.AreEqual(category.Id, product.CategoryId);
        }
        [TestMethod]
        public void OrderTotalCalculationTest()
        {
            var order = new PresAndoClothesShop.Models.Order
            {
                Id = 1,
                Total = 0m,
                OrderDate = DateTime.Now
            };
            var orderItem1 = new PresAndoClothesShop.Models.OrderItem
            {
                Id = 1,
                OrderId = order.Id,
                ProductId = 1,
                Quantity = 2,
                Price = 19.99m
            };
            var orderItem2 = new PresAndoClothesShop.Models.OrderItem
            {
                Id = 2,
                OrderId = order.Id,
                ProductId = 2,
                Quantity = 1,
                Price = 49.99m
            };
            order.Total = (orderItem1.Quantity * orderItem1.Price) + (orderItem2.Quantity * orderItem2.Price);
            Assert.AreEqual(89.97m, order.Total);
        }
        [TestMethod]
        public void CategoryNameNotNullTest()
        {
            var category = new PresAndoClothesShop.Models.Category
            {
                Id = 5,
                Name = "Shoes"
            };

            Assert.IsNotNull(category.Name);
        }

        [TestMethod]
        public void ProductPriceGreaterThanZeroTest()
        {
            var product = new PresAndoClothesShop.Models.Product
            {
                Id = 10,
                Name = "Hat",
                Price = 15.50m,
                CategoryId = 1
            };

            Assert.IsTrue(product.Price > 0);
        }

        [TestMethod]
        public void ProductNameNotEmptyTest()
        {
            var product = new PresAndoClothesShop.Models.Product
            {
                Id = 11,
                Name = "Coat",
                Price = 99.99m,
                CategoryId = 2
            };

            Assert.IsFalse(string.IsNullOrEmpty(product.Name));
        }

        [TestMethod]
        public void CartItemQuantityPositiveTest()
        {
            var cartItem = new PresAndoClothesShop.Models.CartItem
            {
                Id = 20,
                ProductId = 5,
                Quantity = 4
            };

            Assert.IsTrue(cartItem.Quantity > 0);
        }

        [TestMethod]
        public void CartItemHasProductTest()
        {
            var cartItem = new PresAndoClothesShop.Models.CartItem
            {
                Id = 21,
                ProductId = 6,
                Quantity = 1
            };

            Assert.AreNotEqual(0, cartItem.ProductId);
        }

        [TestMethod]
        public void OrderTotalPositiveTest()
        {
            var order = new PresAndoClothesShop.Models.Order
            {
                Id = 10,
                Total = 120.00m,
                OrderDate = DateTime.Now
            };

            Assert.IsTrue(order.Total > 0);
        }

        [TestMethod]
        public void OrderDateTodayTest()
        {
            var order = new PresAndoClothesShop.Models.Order
            {
                Id = 11,
                Total = 50,
                OrderDate = DateTime.Now
            };

            Assert.AreEqual(DateTime.Now.Date, order.OrderDate.Date);
        }

        [TestMethod]
        public void OrderItemPricePositiveTest()
        {
            var item = new PresAndoClothesShop.Models.OrderItem
            {
                Id = 15,
                OrderId = 3,
                ProductId = 2,
                Quantity = 1,
                Price = 29.99m
            };

            Assert.IsTrue(item.Price > 0);
        }

        [TestMethod]
        public void OrderItemTotalCalculationTest()
        {
            var item = new PresAndoClothesShop.Models.OrderItem
            {
                Quantity = 3,
                Price = 10m
            };

            var total = item.Quantity * item.Price;

            Assert.AreEqual(30m, total);
        }

        [TestMethod]
        public void MultipleProductsTest()
        {
            var products = new List<PresAndoClothesShop.Models.Product>
    {
        new PresAndoClothesShop.Models.Product { Id = 1, Name = "A", Price = 10 },
        new PresAndoClothesShop.Models.Product { Id = 2, Name = "B", Price = 20 },
        new PresAndoClothesShop.Models.Product { Id = 3, Name = "C", Price = 30 }
    };

            Assert.AreEqual(3, products.Count);
        }

        [TestMethod]
        public void ProductsTotalPriceTest()
        {
            var products = new List<PresAndoClothesShop.Models.Product>
    {
        new PresAndoClothesShop.Models.Product { Price = 10 },
        new PresAndoClothesShop.Models.Product { Price = 20 },
        new PresAndoClothesShop.Models.Product { Price = 30 }
    };

            decimal total = 0;
            foreach (var p in products)
            {
                total += p.Price;
            }

            Assert.AreEqual(60, total);
        }

        [TestMethod]
        public void CartItemTotalTest()
        {
            var cartItem = new PresAndoClothesShop.Models.CartItem
            {
                Quantity = 2
            };

            var price = 15m;
            var total = cartItem.Quantity * price;

            Assert.AreEqual(30m, total);
        }

        [TestMethod]
        public void OrderMultipleItemsTest()
        {
            var items = new List<PresAndoClothesShop.Models.OrderItem>
    {
        new PresAndoClothesShop.Models.OrderItem { Quantity = 1, Price = 10 },
        new PresAndoClothesShop.Models.OrderItem { Quantity = 2, Price = 5 }
    };

            decimal total = 0;
            foreach (var item in items)
            {
                total += item.Quantity * item.Price;
            }

            Assert.AreEqual(20m, total);
        }

        [TestMethod]
        public void CategoryMultipleProductsTest()
        {
            var category = new PresAndoClothesShop.Models.Category
            {
                Id = 1,
                Name = "Test"
            };

            var products = new List<PresAndoClothesShop.Models.Product>
    {
        new PresAndoClothesShop.Models.Product { CategoryId = 1 },
        new PresAndoClothesShop.Models.Product { CategoryId = 1 }
    };

            Assert.IsTrue(products.All(p => p.CategoryId == category.Id));
        }

        [TestMethod]
        public void ProductChangePriceTest()
        {
            var product = new PresAndoClothesShop.Models.Product
            {
                Price = 10
            };

            product.Price = 20;

            Assert.AreEqual(20, product.Price);
        }
    }
}
