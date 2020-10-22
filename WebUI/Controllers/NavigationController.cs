using Castle.Core.Internal;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

using WebUI.Models;
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
            IEnumerable<ProductGame> games = repository.Products.Select(p => p.ProductGame).Distinct();
            return PartialView(games);
        }
        public PartialViewResult CategoryMenu(string currentGame)
        {
            GetCurrentGame(currentGame);
            string selectedUrl = repository.Products.Where(p => p.ProductGame.GameName == (string)Session["SelectedGame"]).Select(p => p.ProductGame.GameShortUrl).FirstOrDefault();

            CategoryViewModel result = new CategoryViewModel
            {
                categories = repository.Products.Where(p => p.ProductGame.GameName == (string)Session["SelectedGame"]).Select(p => p.ProductCategory.ProductCategoryName).Distinct().OrderBy(x => x),
                currentGame = selectedUrl
            };
            return PartialView(result);
        }
        public PartialViewResult GameCategoryMenu()
        {
            var cat = repository.Products.Select(p => p.ProductCategory).Select(c => new { c.ProductGame.GameName, c.ProductCategoryName }).Distinct();

            GameCategoryViewModel model = new GameCategoryViewModel
            {
                Games = repository.Products.Select(p => p.ProductGame).Distinct(),
                ProductCategories = cat.AsEnumerable().Select(item => new KeyValuePair<string, string>(item.GameName, item.ProductCategoryName)).ToList()
            };

            return PartialView(model);
        }
        public void GetCurrentGame(string currentGame)
        {
            Session["SelectedGame"] = currentGame.IsNullOrEmpty() ? (string)Session["SelectedGame"] : repository.Products.Where(p => p.ProductGame.GameShortUrl == currentGame).Select(p => p.ProductGame.GameName).FirstOrDefault();
        }
    }
}