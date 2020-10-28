using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;
using System;
using Castle.Core.Internal;

namespace WowCarry.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IProductRepository ProdRepository;
        IOptionsRepository OptRepository;
        IHtmlBlockRepository BlockRepository;
        ISEORepository SEORepository;
        public AdminController(IProductRepository prodRep, IOptionsRepository optRep, IHtmlBlockRepository blockRep, ISEORepository sEORep)
        {
            ProdRepository = prodRep;
            OptRepository = optRep;
            BlockRepository = blockRep;
            SEORepository = sEORep;
        }
        public ViewResult Admin()
        {
            return View();
        }
        public ViewResult AdminProducts()
        {
            return View(ProdRepository.Products);
        }
        public ViewResult AdminOptions()
        {
            return View(OptRepository.Options);
        }
        public ViewResult AdminProductGames()
        {
            return View(ProdRepository.Products.Select(p=>p.ProductGame));
        }
        public ViewResult AdminHtmlBlocks()
        {
            return View(BlockRepository.HtmlBlocks);
        }
        public ViewResult AdminSEO()
        {
            return View(SEORepository.SEOs);
        }
    }
}