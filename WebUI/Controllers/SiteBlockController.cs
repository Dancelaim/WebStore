using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class SiteBlockController : Controller
    {
        private IHtmlBlockRepository repository;

        public SiteBlockController(IHtmlBlockRepository repo)
        {
            repository = repo;
        }
        // GET: SiteBlock
        public PartialViewResult SiteBlock(String currentGame = null)
        {
            var routeValues = HttpContext.Request.RequestContext.RouteData.Values;
            string currentController = (string)routeValues["controller"];

            SiteBlockViewModel SiteBlocks = new SiteBlockViewModel
            {
                HtmlBlocks = repository.HtmlBlocks.Where(b => b.SitePage == (!string.IsNullOrEmpty(currentGame) ? currentGame : currentController)).OrderBy(s=>s.Order),
                HtmlBlocksChildren = repository.HtmlBlocks.Where(b => b.SitePage == (!string.IsNullOrEmpty(currentGame) ? currentGame : currentController)).SelectMany(b => b.HtmlBlocksChildren).OrderBy(ch =>ch.ChildOrder)
            };
            return PartialView(SiteBlocks);
        }
    }
}