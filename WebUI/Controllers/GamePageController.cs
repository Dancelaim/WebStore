using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Controllers;
using WowCarry.Domain.Abstract;
using WowCarry.Domain.Entities;

namespace WebUI.Controllers
{
    public class GamePageController : Controller
    {
        IEntityRepository EntityRepository;

        public GamePageController(IEntityRepository entityRepo)
        {
            EntityRepository = entityRepo;
        }
        public ActionResult GameDetails(string currentGame)
        {
            ProductGame result = EntityRepository.Products.Where(p => p.ProductGame.GameShortUrl == currentGame).Select(p => p.ProductGame).FirstOrDefault();

            Session["SelectedGame"] = result.GameName;
            return View(result);
        }
    }
}