using WebUI.Models;
using WebUI.HtmlHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WowCarry.UnitTests.Tests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // Организация - создание нескольких тестовых игр
            Product game1 = new Product { ProductId = Guid.NewGuid(), ProductName = "Игра1" };
            Product game2 = new Product { ProductId = Guid.NewGuid(), ProductName = "Игра2" };

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.AddItem(game1);
            cart.AddItem(game2);
            List<CartLine> results = cart.Lines.ToList();

            // Утверждение
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Product, game1);
            Assert.AreEqual(results[1].Product, game2);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // Организация - создание нескольких тестовых игр
            Product game1 = new Product { ProductId = Guid.NewGuid(), ProductName = "Игра1" };
            Product game2 = new Product { ProductId = Guid.NewGuid(), ProductName = "Игра2" };

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.AddItem(game1, 1);
            cart.AddItem(game2, 1);
            cart.AddItem(game1, 5);
            List<CartLine> results = cart.Lines.OrderBy(c => c.Product.ProductId).ToList();

            // Утверждение
            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Quantity, 6);    // 6 экземпляров добавлено в корзину
            Assert.AreEqual(results[1].Quantity, 1);
        }

        [TestMethod]
        public void Can_Remove_Line()
        {
            // Организация - создание нескольких тестовых игр
            Product game1 = new Product { ProductId = Guid.NewGuid(), ProductName = "Игра1" };
            Product game2 = new Product { ProductId = Guid.NewGuid(), ProductName = "Игра2" };
            Product game3 = new Product { ProductId = Guid.NewGuid(), ProductName = "Игра3" };


            // Организация - создание корзины
            Cart cart = new Cart();

            // Организация - добавление нескольких игр в корзину
            cart.AddItem(game1, 1);
            cart.AddItem(game2, 4);
            cart.AddItem(game3, 2);
            cart.AddItem(game2, 1);

            // Действие
            cart.RemoveLine(game2);

            // Утверждение
            Assert.AreEqual(cart.Lines.Where(c => c.Product == game2).Count(), 0);
            Assert.AreEqual(cart.Lines.Count(), 2);
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            Guid productId1 = Guid.NewGuid();
            Guid productId2 = Guid.NewGuid();


            ProductPrice productPrice1 = new ProductPrice { ProductPriceId = Guid.NewGuid(), ProductId = productId1, Price = 43 };
            ProductPrice productPrice2 = new ProductPrice { ProductPriceId = Guid.NewGuid(), ProductId = productId2, Price = 27 };

            // Организация - создание нескольких тестовых игр
            Product game1 = new Product { ProductId = productId1, ProductName = "Игра1" };
            Product game2 = new Product { ProductId = productId2, ProductName = "Игра2" };

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.AddItem(game1, 1);
            cart.AddItem(game2, 1);
            cart.AddItem(game1, 5);
            decimal result = cart.ComputeTotalValue();

            // Утверждение
            Assert.AreEqual(result, 285);
        }

        [TestMethod]
        public void Can_Clear_Contents()
        {
            // Организация - создание нескольких тестовых игр
            Product game1 = new Product { ProductId = Guid.NewGuid(), ProductName = "Игра1" };
            Product game2 = new Product { ProductId = Guid.NewGuid(), ProductName = "Игра2" };

            // Организация - создание корзины
            Cart cart = new Cart();

            // Действие
            cart.AddItem(game1, 1);
            cart.AddItem(game2, 1);
            cart.AddItem(game1, 5);
            cart.Clear();

            // Утверждение
            Assert.AreEqual(cart.Lines.Count(), 0);
        }
    }
}