using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WowCarry.Domain.Abstract;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            IEnumerable<string> categories = repository.Products
            .Select(p => p.ProductCategory.ProductCategoryName)
            .Distinct()
            .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}