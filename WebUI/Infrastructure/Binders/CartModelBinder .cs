﻿using System.Web.Mvc;
using WowCarry.Domain.Entities;

namespace WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        
        public object BindModel(System.Web.Mvc.ControllerContext controllerContext,ModelBindingContext bindingContext)
        {
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }

            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            return cart;
        }
    }
}