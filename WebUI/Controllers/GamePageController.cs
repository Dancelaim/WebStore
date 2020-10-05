using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Abstract;

namespace GameStore.WebUI.Controllers
{
    public class GamePageController : Controller
    {
        private IProductGameRepository repository;
        public GamePageController(IProductGameRepository repo)
        {
            repository = repo;
        }

        public ActionResult GameDetails(string currentGame)
        {
            object game = currentGame;

            return View(game);
        }
    }
}