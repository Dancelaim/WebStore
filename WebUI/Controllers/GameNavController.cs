using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WowCarry.Domain.Abstract;
using WowCarry.Domain.Entities;

namespace WebUI.Controllers
{
    public class GameNavController : Controller
    {
        private IProductGameRepository repository;

        public GameNavController(IProductGameRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult GameMenu()
        {
            IEnumerable<ProductGame> games = repository.ProductGames.Distinct();
            return PartialView(games);
        }
    }
}