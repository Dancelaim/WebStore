﻿using GameStore.WebUI.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WowCarry.Domain.Abstract;

namespace WebUI.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Home()
        {
            @ViewBag.currentGame = "Select Game";
            Session["SelectedGame"] = null;
            return View();
        }
    }
}