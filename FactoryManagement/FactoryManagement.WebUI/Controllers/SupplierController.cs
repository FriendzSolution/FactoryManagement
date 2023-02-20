using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.Controllers
{
    public class SupplierController : BaseController
    {
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}