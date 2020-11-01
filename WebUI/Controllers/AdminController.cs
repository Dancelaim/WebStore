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
        public AdminController(IProductRepository prodRep, IOptionsRepository optRep, IHtmlBlockRepository blockRep, ISEORepository sEORep, IGameRepository gameRep )
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
            return View(GameRepository.Games);
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