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
        IProductRepository ProdRepository;
        IOptionsRepository OptRepository;
        IHtmlBlockRepository BlockRepository;
        ISEORepository SEORepository;
        IGameRepository GameRepository;
        public AdminController(IProductRepository prodRep, IOptionsRepository optRep, IHtmlBlockRepository blockRep, ISEORepository sEORep, IGameRepository gameRep)
        {
            ProdRepository = prodRep;
            OptRepository = optRep;
            BlockRepository = blockRep;
            SEORepository = sEORep;
            GameRepository = gameRep;
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
                    return View("List" + type, ProdRepository.Products);
                case "ProductOption":
                    return View("List" + type, OptRepository.Options);
                case "ProductGame":
                    return View("List" + type, GameRepository.Games);
                case "HtmlBlocks":
                    return View("List" + type, BlockRepository.HtmlBlocks);
                case "SEO":
                    return View("List" + type, SEORepository.SEOs);
                default: return View("Admin");
            }
        }
        public ViewResult Edit(Guid Id, string type, string game)
        {
            switch (type)
            {
                case "Product":
                    return View("Edit" + type, new ProductDetails(ProdRepository.Products.Where(p => p.ProductId == Id).FirstOrDefault(), GameRepository.Games, GameRepository.Games.Where(g => game == null || g.GameName == game).SelectMany(g => g.ProductCategory)));
                case "ProductOption":
                    return View("Edit" + type, OptRepository.Options.Where(p => p.ProductOptionId == Id).FirstOrDefault());
                case "ProductGame":
                    return View("Edit" + type, GameRepository.Games.Where(p => p.ProductGameId == Id).FirstOrDefault());
                case "HtmlBlocks":
                    return View("Edit" + type, BlockRepository.HtmlBlocks.Where(p => p.SiteBlockId == Id).FirstOrDefault());
                case "SEO":
                    return View("Edit" + type, SEORepository.SEOs.Where(p => p.SEOId == Id).FirstOrDefault());
                default: return View("Admin");
            }
        }
        public ViewResult Create(string type)
        {
            switch (type)
            {
                case "Product":
                    return View("Create" + type, ProdRepository);
                case "ProductOption":
                    return View("Create" + type, OptRepository);
                case "ProductGame":
                    return View("Create" + type, GameRepository);
                case "HtmlBlocks":
                    return View("Create" + type, BlockRepository);
                case "SEO":
                    return View("Create" + type, SEORepository);
                default: return View("Admin");
            }
        }
        [HttpPost]
        public PartialViewResult OptionsList(string optionName,Guid prodId)
        {
            var selectedOption = ProdRepository.Products.Where(p => p.ProductId == prodId).FirstOrDefault().ProductOptions.Where(o => o.OptionName == optionName).FirstOrDefault();

            return PartialView(new ProductOptionDetails(selectedOption));
        }
    }
}