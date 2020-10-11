﻿using Castle.Core.Internal;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WowCarry.Domain.Abstract;
using WowCarry.Domain.Entities;

namespace WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private IProductRepository repository;

        public NavigationController(IProductRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult GameMenu()
        {
            IEnumerable<ProductGame> games = repository.Products.Select(p => p.ProductGame).Distinct();
            return PartialView(games);
        }
        public PartialViewResult CategoryMenu(string currentGame)
        {
            string SelectedGame = (string)Session["SelectedGame"];

            if (SelectedGame == null)
            {
                SelectedGame = currentGame;
                Session["SelectedGame"] = SelectedGame;
            }

            string game = !currentGame.IsNullOrEmpty() ? currentGame : SelectedGame;

            IEnumerable<string> categories = repository.Products.Where(p =>  p.ProductGame.GameShortUrl == game).Select(p => p.ProductCategory.ProductCategoryName).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
        public PartialViewResult GameCategoryMenu()
        {
            GameCategoryViewModel model = new GameCategoryViewModel
            {
                Games = repository.Products.Select(p => p.ProductGame.GameName).OrderBy(x => x),
                ProductCategories = repository.Products.Select(p => p.ProductCategory).Distinct().OrderBy(x => x)
            };

            return PartialView(model);
        }
    }
}