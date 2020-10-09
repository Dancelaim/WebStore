using Castle.Core.Internal;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WowCarry.Domain.Abstract;
using WowCarry.Domain.Entities;

namespace WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private IProductRepository repository;
        public NavigationController(IProductRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult GameMenu()
        {
            IEnumerable<ProductGame> games = repository.Products.Select(p => p.ProductGame).Distinct().OrderBy(x => x);
            return PartialView(games);
        }
        public PartialViewResult CategoryMenu(string currentGame)
        {
            if (currentGame.IsNullOrEmpty()) 
            {
               currentGame = repository.Products.Where(p => p.ProductGame.GameName == ViewBag.currentGame).Select(sp => sp.ProductGame.GameShortUrl).FirstOrDefault();
            }
            IEnumerable<string> categories = repository.Products.Where(p => p.ProductGame.GameShortUrl == currentGame).Select(p => p.ProductCategory.ProductCategoryName).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}