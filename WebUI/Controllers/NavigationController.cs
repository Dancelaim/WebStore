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
        IEntityRepository EntityRepository;

        public NavigationController(IEntityRepository entityRepo)
        {
            EntityRepository = entityRepo;
        }
        public PartialViewResult GameMenu()
        {
            IEnumerable<ProductGame> games = EntityRepository.Products.Select(p => p.ProductGame).Distinct();
            return PartialView(games);
        }
        public PartialViewResult CategoryMenu(string currentGame)
        {
            GetCurrentGame(currentGame);
            string selectedUrl = EntityRepository.Products.Where(p => p.ProductGame.GameName == (string)Session["SelectedGame"]).Select(p => p.ProductGame.GameShortUrl).FirstOrDefault();

            CategoryViewModel result = new CategoryViewModel
            {
                categories = EntityRepository.Products.Where(p => p.ProductGame.GameName == (string)Session["SelectedGame"]).Select(p => p.ProductCategory.ProductCategoryName).Distinct().OrderBy(x => x),
                currentGame = selectedUrl
            };
            return PartialView(result);
        }
        public PartialViewResult GameCategoryMenu(bool isMobile = false)
        {
            var cat = EntityRepository.Products.Select(p => p.ProductCategory).Select(c => new { c.ProductGame.GameName, c.ProductCategoryName }).Distinct();

            GameCategoryViewModel model = new GameCategoryViewModel
            {
                Games = EntityRepository.Products.Select(p => p.ProductGame).Distinct(),
                ProductCategories = cat.AsEnumerable().Select(item => new KeyValuePair<string, string>(item.GameName, item.ProductCategoryName)).ToList()
            };

            if (isMobile)
                return PartialView("MobileMenu", model);

            return PartialView(model);
        }
        public void GetCurrentGame(string currentGame)
        {
            Session["SelectedGame"] = string.IsNullOrEmpty(currentGame)? (string)Session["SelectedGame"] : EntityRepository.Products.Where(p => p.ProductGame.GameShortUrl == currentGame).Select(p => p.ProductGame.GameName).FirstOrDefault();
        }
    }
}