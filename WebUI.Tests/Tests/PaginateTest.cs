using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebUI.Models;
using WowCarry.Domain.Abstract;
using WowCarry.Domain.Entities;
using WowCarry.WebUI.Controllers;

namespace WowCarry.UnitTests.Tests
{
    [TestClass]
    public class PaginateTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Организация (arrange)
            Mock<IEntityRepository> mock = new Mock<IEntityRepository>();

            Guid testCat1 = new Guid();
            Guid testCat2 = new Guid();


            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {ProductName = "Игра1",ProductCategoryId = testCat1},
                new Product {ProductName = "Игра2",ProductCategoryId = testCat2},
                new Product {ProductName = "Игра3",ProductCategoryId = testCat1},
                new Product {ProductName = "Игра4",ProductCategoryId = testCat2},
                new Product {ProductName = "Игра5",ProductCategoryId = testCat1}
            });
            ProductsController controller = new ProductsController(mock.Object)
            {
                pageSize = 3
            };

            // Действие (act)
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null,null,2).Model;

            // Утверждение (assert)
            List<Product> products = result.Products.ToList();

            Assert.IsTrue(products.Count == 2);
            Assert.AreEqual(products[0].ProductName, "Игра4");
            Assert.AreEqual(products[1].ProductName, "Игра5");

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);


        }
    }
}