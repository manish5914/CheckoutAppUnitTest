using CheckoutApp_CL.BL;
using CheckoutApp_CL.DAL;
using CheckoutApp_CL.Model;
using Moq;
using NUnit.Framework;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;

namespace CheckoutTest
{
    public class Tests
    {
        InventoryBL inventoryBl;
        [SetUp]
        public void Setup()
        {
            inventoryBl = new InventoryBL(new InventoryDAL());
        }

        [Test]
        public void TestAddtoBasket()
        {
            var mock = new Mock<IInventoryDAL>();
            mock.Setup(z => z.GetInventoryItems()).Returns(new List<InventoryItem>()
            {
                new InventoryItem(){
                    InventoryItemId = 1,
                    Description = "Something",
                    CountInStock = 3,
                    Price=70
                }
            });
            var inventoryBl2 = new InventoryBL(mock.Object);
            inventoryBl.AddToBasket(1);
            Assert.IsTrue(inventoryBl.basket.ContainsKey(1));

        }
        [Test]
        public void TestAddtoBasketException()
        {
            var mock = new Mock<IInventoryDAL>();
            mock.Setup(z => z.GetInventoryItems()).Returns(new List<InventoryItem>()
            {
                new InventoryItem(){
                    InventoryItemId = 1,
                    Description = "Something",
                    CountInStock = 3,
                    Price=70
                }
            });
            var inventoryBl2 = new InventoryBL(mock.Object);
            Assert.Throws<Exception>(() => inventoryBl2.AddToBasket(920));

        }
        [Test]
        public void TestMock()
        {
            var mock = new Mock<IInventoryDAL>();
            mock.Setup(z => z.GetInventoryItems()).Returns(new List<InventoryItem>()
            {
                new InventoryItem(){
                    InventoryItemId = 1,
                    Description = "Something",
                    CountInStock = 1,
                    Price=70
                }
            });
            var inventoryBl2 = new InventoryBL(mock.Object);
            inventoryBl2.AddToBasket(1);
            Assert.IsTrue(inventoryBl2.basket.ContainsKey(1));

        }
        [Test]
        public void TestCheckoutItems()
        {
            var mock = new Mock<IInventoryDAL>();
            mock.Setup(z => z.GetInventoryItems()).Returns(new List<InventoryItem>()
            {
                new InventoryItem(){
                    InventoryItemId = 1,
                    Description = "Something",
                    CountInStock = 3,
                    Price=70
                }
            });
            var inventoryBl2 = new InventoryBL(mock.Object);
            inventoryBl2.AddToBasket(1);
            inventoryBl2.AddToBasket(1);
            Assert.That(inventoryBl2.CheckoutItems(), Is.EqualTo(140));
        }
        [Test]
        public void TestInventory()
        {
            var mock = new Mock<IInventoryDAL>();
            mock.Setup(z => z.GetInventoryItems()).Returns(new List<InventoryItem>()
            {
                new InventoryItem(){
                    InventoryItemId = 1,
                    Description = "Something",
                    CountInStock = 1,
                    Price=70
                }
            });
            var inventoryBl2 = new InventoryBL(mock.Object);
            inventoryBl2.AddToBasket(1);
            inventoryBl2.CheckoutItems();
            Assert.That(inventoryBl2.Items[0].CountInStock, Is.EqualTo(0));
           
        }
        [Test]
        public void TestInventoryLessZero()
        {
            var mock = new Mock<IInventoryDAL>();
            mock.Setup(z => z.GetInventoryItems()).Returns(new List<InventoryItem>()
            {
                new InventoryItem(){
                    InventoryItemId = 1,
                    Description = "Something",
                    CountInStock = 1,
                    Price=70
                }
            });
            var inventoryBl2 = new InventoryBL(mock.Object);
            inventoryBl2.AddToBasket(1);
            inventoryBl2.AddToBasket(1);
            inventoryBl2.CheckoutItems();
            Assert.That(inventoryBl2.Items[0].CountInStock, Is.EqualTo(0));

        }
    }

    //public class InventoryDalMock : IInventoryDAL
    //{
    //    public List<InventoryItem> GetInventoryItems()
    //    {
    //        return new List<InventoryItem>()
    //        {
    //            new InventoryItem()
    //            {
    //                InventoryItemId = 1,
    //                CountInStock = 1,
    //                Price=70
    //            }
    //        };
    //    }

    //    public void SaveNewOrder(ItemOrder newOrder)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void UpdateInventoryCount(List<InventoryItem> updatedList)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
