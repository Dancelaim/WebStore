using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;
using System;

namespace WowCarry.WebUI.Controllers
{
    public  class BlogController : Controller
    {

        IEntityRepository EntityRepository;
        public BlogController(IEntityRepository EntityRep)
        {
            EntityRepository = EntityRep;
        }
        //All blogs for one category
        public ViewResult BlogsCategory(string categoryName)
        {
            return View();
        }
        //Several category blogs
        public ViewResult Blogs()
        {
            return View();
        }
        //One blog
        public ViewResult Blog(Guid BlogId)
        {
            return View();
        }
        //Shorcuts for homepage
        public PartialViewResult BlogShort()
        {
            return PartialView();
        }


    }
}