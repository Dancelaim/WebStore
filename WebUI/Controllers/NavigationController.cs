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
            string SelectedGame = (string)Session["SelectedGame"];

            if (SelectedGame == null)
            {
                SelectedGame = currentGame;
                Session["SelectedGame"] = SelectedGame;
            }

            string game = !currentGame.IsNullOrEmpty() ? currentGame : SelectedGame;

            IEnumerable<string> categories = repository.Products.Where(p =>  p.ProductGame.GameShortUrl == game).Select(p => p.ProductCategory.ProductCategoryName).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
        public PartialViewResult GameCategoryMenu()
        {
            IEnumerable<ProductGame> games = repository.Products.Select(p => p.ProductGame).Distinct().OrderBy(x => x);
            return PartialView(games);
        }
    }
}