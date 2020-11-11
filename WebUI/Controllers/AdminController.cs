using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;
using System;

namespace WowCarry.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IEntityRepository EntityRepository;
        public AdminController(IEntityRepository entityRepo)
        {
            EntityRepository = entityRepo;
        }
        public ViewResult Admin()
        {
            return View();
        }
        public ViewResult List(string type)
        {
            switch (type)
            {
                case "Product":
                    return View("List" + type, EntityRepository.Products);
                case "ProductOption":
                    return View("List" + type, EntityRepository.Options);
                case "ProductGame":
                    return View("List" + type, EntityRepository.Games);
                case "HtmlBlocks":
                    return View("List" + type, EntityRepository.HtmlBlocks);
                case "SEO":
                    return View("List" + type, EntityRepository.SEOs);
                default: return View("Admin");
            }
        }
        public ViewResult Edit(Guid Id, string type, string game)
        {
            switch (type)
            {
                case "Product":
                    return View("Edit" + type, new ProductDetails(EntityRepository.Products.Where(p => p.ProductId == Id).FirstOrDefault(), EntityRepository.Games, EntityRepository.Games.Where(g => game == null || g.GameName == game).SelectMany(g => g.ProductCategory), EntityRepository.SEOs));
                case "ProductOption":
                    return View("Edit" + type, EntityRepository.Options.Where(p => p.ProductOptionId == Id).FirstOrDefault());
                case "ProductGame":
                    return View("Edit" + type, EntityRepository.Games.Where(p => p.ProductGameId == Id).FirstOrDefault());
                case "HtmlBlocks":
                    return View("Edit" + type, EntityRepository.HtmlBlocks.Where(p => p.SiteBlockId == Id).FirstOrDefault());
                case "SEO":
                    return View("Edit" + type, EntityRepository.SEOs.Where(p => p.SEOId == Id).FirstOrDefault());
                default: return View("Admin");
            }
        }
        public ViewResult Create(string type)
        {
            switch (type)
            {
                case "Product":
                    return View("Create" + type, EntityRepository);
                case "ProductOption":
                    return View("Create" + type, EntityRepository);
                case "ProductGame":
                    return View("Create" + type, EntityRepository);
                case "HtmlBlocks":
                    return View("Create" + type, EntityRepository);
                case "SEO":
                    return View("Create" + type, EntityRepository);
                default: return View("Admin");
            }
        }
        [HttpPost]
        public PartialViewResult OptionsList(string optionName,Guid prodId)
        {
            var selectedOption = EntityRepository.Products.Where(p => p.ProductId == prodId).FirstOrDefault().ProductOptions.Where(o => o.OptionName == optionName).FirstOrDefault();

            return PartialView(new ProductOptionDetails(selectedOption));
        }
    }
}