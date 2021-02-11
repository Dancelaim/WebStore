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
                name: "",
                url: "{action}",
                defaults: new { controller = "HomePage"},
                constraints: new { action = "AboutUs||Contacts||FAQ||PrivacyPolicy||Terms||CarryCoins||SetSessionData" }
            );
            routes.MapRoute(
                name: "Login",
                url: "{Login}",
                defaults: new { controller = "Login", action = "Login"},
                constraints: new {Login = "Login" }
            );
            routes.MapRoute(
                name: "Logout",
                url: "{Login}/{Logout}",
                defaults: new { controller = "Login", action = "Logout" },
                constraints: new { Logout = "Logout" }
            );
            routes.MapRoute(
                name: "AjaxLogin",
                url: "{Login}/{AjaxLogin}",
                defaults: new { controller = "Login", action = "AjaxLogin" },
                constraints: new { AjaxLogin = "AjaxLogin" }
            );
            routes.MapRoute(
                name: "AjaxRegistration",
                url: "{Login}/{AjaxRegistration}",
                defaults: new { controller = "Login", action = "AjaxRegistration" },
                constraints: new { AjaxRegistration = "AjaxRegistration" }
            );
            routes.MapRoute(
                name: "CustomerLogout",
                url: "{Login}/{CustomerLogout}",
                defaults: new { controller = "Login", action = "CustomerLogout" },
                constraints: new { CustomerLogout = "CustomerLogout" }
            );

            routes.MapRoute(
                name: "Admin",
                url: "{Admin}",
                defaults: new { controller = "Admin", action = "Admin" },
                constraints: new { Admin = "Admin" }
            );

            routes.MapRoute(
                name: "Account",
                url: "{Account}",
                defaults: new { controller = "Account", action = "Account" },
                constraints: new { Account = "Account" }
            );

            routes.MapRoute(
                name: "AdminItem",
                url: "{Admin}/{Action}",
                defaults: new { controller = "Admin", action = "Admin" },
                constraints: new { Admin = "Admin" }
            );
            routes.MapRoute(
                name: "Article",
                url: "{Blog}/{Article}",
                defaults: new { controller = "Blog", action = "Article" },
                constraints: new { Article = "Article" }
            );
           routes.MapRoute(
                name: "GameBlog",
                url: "{Blog}/{Articles}",
                defaults: new { controller = "Blog", action = "Articles" },
                constraints: new { Articles = "Articles" }
            );
           routes.MapRoute(
                name: "Blog",
                url: "{Blog}",
                defaults: new { controller = "Blog", action = "Blog" },
                constraints: new { Blog = "Blog" }
            );
            routes.MapRoute(
                name: "TagSearch",
                url: "{Blog}/{TagSearch}",
                defaults: new { controller = "Blog", action = "TagSearch" },
                constraints: new { TagSearch = "TagSearch" }
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