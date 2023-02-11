using FactoryManagement.WebUI.CustomAttribute;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.Controllers
{
    [AuthorizationFilter]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

    }
}