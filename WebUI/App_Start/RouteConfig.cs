using System;
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
                name: "Home",
                url: "",
                defaults: new { controller = "HomePage", action = "Home" }
            );

                routes.MapRoute(
                name: "Admin",
                url: "{Admin}",
                defaults: new { controller = "Admin", action = "Admin" },
                constraints: new { Admin = "Admin" }
            );

            routes.MapRoute(
            name: null,
            url: "{Admin}/{Action}",
            defaults: new { controller = "Admin", action = "Admin" },
            constraints: new { controller = "Admin" }
            );

            routes.MapRoute(
                name: "AddToCart",
                url: "{ProductDetails}/{AddToCart}",
                defaults: new { controller = "ProductDetails", action = "AddToCart" },
                constraints: new { AddToCart = "AddToCart" }
            );

            routes.MapRoute(
                name: "RemoveFromCart",
                url: "{Cart}/{RemoveFromCart}",
                defaults: new { controller = "Cart", action = "RemoveFromCart" },
                constraints: new { RemoveFromCart = "RemoveFromCart" }
            );

            routes.MapRoute(
                name: "UpdateCart",
                url: "{Cart}/{UpdateCart}",
                defaults: new { controller = "Cart", action = "UpdateCart" },
                constraints: new { UpdateCart = "UpdateCart" }
            );


            routes.MapRoute(
                 name: "Checkout",
                 url: "{Checkout}",
                 defaults: new { controller = "Checkout", action = "Checkout" },
                 constraints: new { Checkout = "Checkout" }
            );

            routes.MapRoute(
                 name: "GameDetails",
                 url: "{currentGame}",
                 defaults: new { controller = "GamePage", action = "GameDetails" },
                 constraints: new { currentGame = "classic|destiny|poe|hs|lol|valorant|bfa" }
            );

            routes.MapRoute(
                name: "Sorted",
                url: "{selectedGame}/{categoryName}",
                defaults: new { controller = "Products", action = "List", page = 1 }
            );

            routes.MapRoute(
                 name: null,
                 url: "{selectedGame}/{categoryName}/{page}",
                 defaults: new { controller = "Products", action = "List" },
                 constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                 name: "ProductDetails",
                 url: "{productUrl}",
                 defaults: new { controller = "ProductDetails", action = "Details" }
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