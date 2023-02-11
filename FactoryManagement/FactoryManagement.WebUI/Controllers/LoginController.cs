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
        public LoginController()
        {
            _login = new Login();
        }
        // GET: Login
        public ActionResult Index()
        {
            var a= CurrenUser.UserID;
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Validate(string UserName , string Password)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _login.Validate(UserName,Password);
                if (resp.Data != null)
                {
                    var userDTOobj = JsonConvert.SerializeObject(resp.Data);
                    Session["User"] = userDTOobj;
                    resp.IsSuccess = true;
                    //resp.Data = userDTOobj;
                    resp.Msg = "Login Successfully";
                }
                else
                {
                    resp.IsSuccess = false;
                    resp.Msg = "Username or Password is Invalid..!!";
                    resp.Data = null;
                }
            }
            catch (Exception ex)
            {
                resp.Msg = ex.Message;
                resp.IsSuccess = false;
            }
            return Json(resp, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}