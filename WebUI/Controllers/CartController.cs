using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;
using System;
using Castle.Core.Internal;

namespace WowCarry.WebUI.Controllers
{
    public  class CartController : Controller
    { 

        private IProductRepository repository;
        public CartController(IProductRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult CartPopUp(Cart cart)
        {
            return PartialView(cart);
        }
        [HttpPost]
        public ActionResult RemoveFromCart(Cart cart,Guid productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return PartialView("CartPopUp", cart);
        }
        public PartialViewResult UpdateCart(Cart cart)
        {
            return PartialView("CartPopUp", cart);
        }
    }
}