using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WowCarry.Domain.Abstract;
using WowCarry.Domain.Entities;

namespace WebUI.Controllers
{
    public class HomePageController : Controller
    {
        IEntityRepository EntityRepository;
        public HomePageController(IEntityRepository entityRepo)
        {
            EntityRepository = entityRepo;
        }
        public ActionResult Home()
        {
            Session["SelectedGame"] = "Select Game";
            return View();
        }
        public PartialViewResult RecommendedProducts(string game)
        {
            IEnumerable<Product> result = EntityRepository.Products.Where(p=>p.ProductGame.GameName == game).Take(4);
            return PartialView(result);
        }
        public ViewResult AboutUs()
        {
            return View();

        }
        public ViewResult Contacts()
        {
            return View();
        }
        public ViewResult FAQ()
        {
            return View();
        }
        public ViewResult PrivacyPolicy()
        {
            return View();
        }
        public ViewResult Terms()
        {
            return View();
        }
        public ViewResult CarryCoins()
        {
            return View();
        }

        [HttpPost]
        public void SetSessionData()
        {

        }
    }
}