using FactoryManagement.WebUI.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.Controllers
{
    [AuthorizationFilter]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            var a = CurrenUser.UserID;
            return View();
        }

    }
}