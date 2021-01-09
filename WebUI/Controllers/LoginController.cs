using System.Web.Mvc;
using System.Web.Security;
using WowCarry.Domain.Entities;
using WebUI.Models;
using System.Linq;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
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
                    return RedirectToAction("Admin", "Admin");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}