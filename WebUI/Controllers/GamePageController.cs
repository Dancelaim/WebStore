﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Controllers;
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
            string gameName = repository.ProductGames.Where(g => g.GameShortUrl == currentGame).Select(go => go.GameName).FirstOrDefault();
            ViewBag.currentGame = gameName;

            object game = currentGame;
            return View(game);
        }
    }
}