using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Controllers;
using WowCarry.Domain.Abstract;

namespace GameStore.WebUI.Controllers
{
    public class GamePageController : Controller
    {
        public ActionResult GameDetails()
        {
            return View();
        }
    }
}