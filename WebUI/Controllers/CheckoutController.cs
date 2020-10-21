using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;
using System;
using Castle.Core.Internal;

namespace GameStore.WebUI.Controllers
{
    public  class CheckoutController : Controller
    { 
        private IProductRepository repository;
        public CheckoutController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Checkout(Cart cart)
        {
            return View(cart);
        }
    }
}