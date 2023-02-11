using FactoryManagement.Common;
using FactoryManagement.Common.Model;
using FactoryManagement.Interface.UIinterface;
using FactoryManagement.Repository.UIRepo;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.Controllers
{
    public class RoleController : BaseController
    {
        private IRole _role;
        public RoleController()
        {
            _role = new Role();
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public async Task<ActionResult> SaveRole(ModelRole modelRole)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                //modelRole.CreatedBy = CurrenUser.UserID;
                resp.Data = await _role.SaveRole(modelRole);
                if (resp.Data != null)
                {
                    resp.IsSuccess = true;
                }
                else
                {
                    resp.IsSuccess = false;
                    resp.Msg = "Something went Wrong";
                }
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