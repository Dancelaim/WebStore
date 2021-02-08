﻿using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;
using System;
using System.Collections.Generic;

namespace WowCarry.WebUI.Controllers
{
    public  class BlogController : Controller
    {

        IEntityRepository EntityRepository;
        public BlogController(IEntityRepository EntityRep)
        {
            EntityRepository = EntityRep;
        }
        public ViewResult Article(Guid articleId)
        {
            Article result = EntityRepository.Articles.Where(a => a.ArticleId == articleId).FirstOrDefault();
            return View(result);
        }
        public ViewResult Articles(string game)
        {
            IEnumerable<Article> result = EntityRepository.Articles.Where(a => a.ProductGame.GameName == game);
            return View(result);
        }
        public ViewResult Blog()
        {
            IEnumerable<Article> result = EntityRepository.Articles;
            return View(result);
        }
        public ViewResult TagSearch(string Tag)
        {
            TagSearchViewModel result = new TagSearchViewModel()
            {
                articles = EntityRepository.Articles.Where(a=>a.Tags.Contains(Tag)),
                tags = EntityRepository.Articles.Select(a => a.Tags).Distinct()
            };
            return View(result);
        }
        public PartialViewResult LatestPosts()
        {
            IEnumerable<Article> result = EntityRepository.Articles.OrderBy(a => a.ArticlePostTime).Take(4);
            return PartialView(result);
        }
    }
}