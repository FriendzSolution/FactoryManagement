using FactoryManagement.Common;
using FactoryManagement.Common.Model;
using FactoryManagement.Repository.UIRepo;
using FactoryManagement.Interface.UIinterface;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.Controllers
{
    public class LoginController : BaseController
    {
        private ILogin _login;
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Validate()
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = _login.Validate();
                if (resp.Data != null)
                {
                    string userJSON = Convert.ToString(resp.Data);
                    var userDTOobj = JsonConvert.DeserializeObject<ModelLogin>(userJSON);
                    Session["User"]= userJSON;
                    resp.Data = userDTOobj;
                }
                else
                {
                    resp.Msg = "Something Went Wrong..!!!";
                }
                return Json(resp);
            }
            catch (Exception ex)
            {
                resp.Msg = ex.Message;
                resp.IsSuccess = false;
            }
            return Json(resp);
        }

    }
}