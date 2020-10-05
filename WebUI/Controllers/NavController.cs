using Castle.Core.Internal;

using System.Collections.Generic;
using System.Linq;
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
        public PartialViewResult Menu(string currentGame)
        {
            string game = currentGame.IsNullOrEmpty() ? ViewBag.CurrentGame : currentGame;
            IEnumerable<string> categories = repository.Products.Where(p => p.ProductGame.GameShortUrl == game).Select(p => p.ProductCategory.ProductCategoryName).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}