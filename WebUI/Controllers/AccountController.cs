using System.Linq;
using System.Web.Mvc;
using WowCarry.Domain.Entities;
using WowCarry.Domain.Abstract;
using WebUI.Models;
using System;
using System.Collections.Generic;
using System.Web.Security;

namespace WowCarry.WebUI.Controllers
{
    [Authorize(Roles = "Root Account")]
    public class AccountController : Controller
    {

    }
}