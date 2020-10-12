using Castle.Core.Internal;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            IEnumerable<string> categories = repository.Products.Where(p =>  p.ProductGame.GameShortUrl == GetCurrentGame(currentGame)).Select(p => p.ProductCategory.ProductCategoryName).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
        public PartialViewResult GameCategoryMenu()
        {
            GameCategoryViewModel model = new GameCategoryViewModel
            {
                Games = repository.Products.Select(p => p.ProductGame.GameName).OrderBy(x => x),
                ProductCategories = repository.Products.Select(p=>p.ProductCategory).ToDictionary(p => p.ProductGame.GameName,p=>p.ProductCategoryName)
            };

            return PartialView(model);
        }
        private string GetCurrentGame(string currentGame)
        {
            string SelectedGame = currentGame.IsNullOrEmpty() ? (string)Session["SelectedGame"] : currentGame;

            if (!SelectedGame.IsNullOrEmpty())
            {
                Session["SelectedGame"] = SelectedGame;
            }
            return SelectedGame;
        }
    }
}