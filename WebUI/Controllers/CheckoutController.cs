﻿using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;
using System;
using Castle.Core.Internal;

namespace WowCarry.WebUI.Controllers
{
    public  class CheckoutController : Controller
    { 
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;
        public CheckoutController(IProductRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }
        public ViewResult Checkout()
        {
            return View(new OrderDetails());
        }
        [HttpPost]
        public ActionResult Checkout(Cart cart,OrderDetails orderDetails)
        {
            if (cart.Lines.Any())
            {
                if (ModelState.IsValid)
                {
                    orderProcessor.ProcessOrder(cart, orderDetails);
                    cart.Clear();
                    return View("Completed");
                }
                return View(orderDetails);
            }
            else
            {
                return RedirectToRoute("Home");
            }
        }
        public PartialViewResult CartView(Cart cart)
        {
            return PartialView(cart);
        }
    }
}