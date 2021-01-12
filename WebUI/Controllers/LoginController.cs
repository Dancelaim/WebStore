using System.Web.Mvc;
using System.Web.Security;
using WowCarry.Domain.Entities;
using WebUI.Models;
using System.Linq;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login(bool isWebView = false)
        {
            if (isWebView)
            {
                return PartialView("CustomerLogin");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            using (WowCarryEntities context = new WowCarryEntities())
            {
                bool IsValidUser = context.Users.Any(user => user.UserName.ToLower() == model.UserName.ToLower() && user.UserPassword == model.Password);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return  RedirectToAction("Admin", "Admin");
                }
                ModelState.AddModelError("", "Invalid Username or Password");
                return PartialView();
            }
        }
        [HttpPost]
        public bool AjaxLogin(string userName, string password)
        {
            using (WowCarryEntities context = new WowCarryEntities())
            {
                bool IsValidUser = context.Customers.Any(user => user.Name.ToLower() == userName.ToLower() && user.Password == password);
                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(userName, false);
                    return true;
                }
                return false;
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}