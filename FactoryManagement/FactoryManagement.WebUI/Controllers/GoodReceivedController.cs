using FactoryManagement.Common;
using FactoryManagement.Interface.UIinterface;
using FactoryManagement.Repository.UIRepo;
using FactoryManagement.WebUI.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.Controllers
{
    [AuthorizationFilter]
    public class GoodReceivedController : BaseController
    {
        private IGoodReceived _goodReceived;
        public GoodReceivedController()
        {
            _goodReceived = new GoodReceived();
        }
        // GET: GoodReceived
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetDropDownValue()
        {
            ResponseModel resp = new ResponseModel();
            try
            {

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.Msg = ex.Message;
            }
            return Json(resp);
        }

    }
}