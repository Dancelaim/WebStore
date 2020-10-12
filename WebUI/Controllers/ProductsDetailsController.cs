using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebUI.Models;

using WowCarry.Domain.Abstract;
using WowCarry.Domain.Entities;

namespace WowCarry.WebUI.Controllers
{
    public class ProductsDetailsController : Controller
    {
        private IProductRepository repository;
        public ProductsDetailsController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Details()
        { 
            return View();
        }
    }
}