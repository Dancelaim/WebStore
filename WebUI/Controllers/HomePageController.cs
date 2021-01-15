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

        public PartialViewResult RecommendedProducts()
        {
            var random = new Random();
            IEnumerable<Product> result = EntityRepository.Products.Take(random.Next(10));
            return PartialView(result);
        }
    }
}