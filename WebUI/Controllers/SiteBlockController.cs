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
        IEntityRepository EntityRepository;

        public SiteBlockController(IEntityRepository entityRepo)
        {
            EntityRepository = entityRepo;
        }
        // GET: SiteBlock
        public PartialViewResult SiteBlocks(String currentGame = null)
        {
            var routeValues = HttpContext.Request.RequestContext.RouteData.Values;
            string currentController = (string)routeValues["controller"];

            SiteBlockViewModel SiteBlocks = new SiteBlockViewModel
            {
                HtmlBlocks = EntityRepository.HtmlBlocks.Where(b => b.SitePage == (!string.IsNullOrEmpty(currentGame) ? currentGame : currentController)).OrderBy(s=>s.Order),
                HtmlBlocksChildren = EntityRepository.HtmlBlocks.Where(b => b.SitePage == (!string.IsNullOrEmpty(currentGame) ? currentGame : currentController)).SelectMany(b => b.HtmlBlocksChildren).OrderBy(ch =>ch.ChildOrder)
            };
            return PartialView(SiteBlocks);
        }
        public PartialViewResult SiteBlock(string title)
        {
            var routeValues = HttpContext.Request.RequestContext.RouteData.Values;
            string currentController = (string)routeValues["controller"];

            HtmlBlocks result = EntityRepository.HtmlBlocks.Where(s => s.ParentTitle == title && s.SitePage == currentController).FirstOrDefault();

            return PartialView(result);
        }
    }
}