using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebUI.Models;

using WowCarry.Domain.Abstract;
using WowCarry.Domain.Entities;

namespace WowCarry.WebUI.Controllers
{
    public class ProductDetailsController : Controller
    {
        private IProductRepository repository;
        public ProductDetailsController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Details(string productUrl)
        {
            Product product = repository.Products.Where(p => p.ProductCEO.UrlKeyWord == productUrl).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public decimal AddToCart (Cart cart ,Guid? ProductId)
        {
            Product product = repository.Products.Where(p => p.ProductId == ProductId).FirstOrDefault();
            cart.AddItem(product);

            return cart.TotalQty();
        }
    }
    
}