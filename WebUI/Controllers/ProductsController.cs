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
    public class ProductsController : Controller
    {
        private IProductRepository repository;
        public int pageSize = 3;
        public ProductsController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string categoryName,int page = 1)
        {
            ViewBag.currentGame = repository.Products.Where(p => p.ProductCategory.ProductCategoryName == categoryName).Select(sp => sp.ProductGame).FirstOrDefault().GameName.ToString();
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.Where(p=> categoryName == null || p.ProductCategory.ProductCategoryName == categoryName)
                .OrderBy(p => p.ProductUpdateDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = categoryName == null ? repository.Products.Count() : repository.Products.Where(p => p.ProductCategory.ProductCategoryName == categoryName).Count()
                },
                CurrentCategory = categoryName
            };
            return View(model);
        }
    }
}