using System.Web.Mvc;
using System.Web.Security;
using WowCarry.Domain.Entities;
using WebUI.Models;
using System.Linq;

namespace WebUI.Controllers
{
    public class SignUpController : Controller
    {
        public ActionResult Signup()
        {
            return View();
        }
        //TO DO :  Implement SignUP page
        //[HttpPost]
        //public ActionResult Signup(User model)
        //{
        //    using (EmployeeDBContext context = new EmployeeDBContext())
        //    {
        //        context.Users.Add(model);
        //        context.SaveChanges();
        //    }
        //    return RedirectToAction("Login");
        //}
    }
}