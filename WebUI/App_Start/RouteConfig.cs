﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WowCarry.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { controller = "HomePage", action = "Home"}
            );

            routes.MapRoute(
                 name: "GameDetails",
                 url: "{currentGame}",
                 defaults: new { controller = "GamePage", action = "GameDetails" },
                 constraints: new { currentGame = "classic|destiny|poe|hs|lol|valorant|bfa" }
            );

            routes.MapRoute(
                name: "Sorted",
                url: "{categoryName}",
                defaults: new { controller = "Products", action = "List", page = 1 }
            );

            routes.MapRoute(
                 name: null,
                 url: "{categoryName}/{page}",
                 defaults: new { controller = "Products", action = "List" },
                 constraints: new { page = @"\d+" }
            );

  

            //routes.MapRoute(
            //    name: null,
            //    url: "",
            //    defaults: new { controller = "Products", action = "List", category = (string)null, page = 1 }
            //);

            //routes.MapRoute(
            //    name: null,
            //    url: "Page{page}",
            //    defaults: new { controller = "Products", action = "List", category = (string)null },
            //    constraints: new { page = @"\d+" }
            //);

            routes.MapRoute(null, "{controller}/{action}");
        }
    }

}