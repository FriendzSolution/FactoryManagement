using FactoryManagement.Common;
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
    public class DesignHeadController : BaseController
    {
       // private IRole _role;
        public DesignHeadController()
        {
            //_role = new Role();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        //public async Task<ActionResult> SaveRole(ModelRole modelRole)
        //{
        //    ResponseModel resp = new ResponseModel();
        //    try
        //    {
        //        modelRole.CreatedBy = CurrenUser.UserID;
        //        modelRole.ModifyBy = CurrenUser.UserID;
        //        modelRole.fk_Companyid = 1;
        //        resp.Data = await _role.SaveRole(modelRole);
        //        if (resp.Data != null)
        //        {
        //            resp.IsSuccess = true;
        //        }
        //        else
        //        {
        //            resp.IsSuccess = false;
        //            resp.Msg = "Something went Wrong";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resp.IsSuccess = false;
        //        resp.Msg = ex.Message;
        //    }
        //    return Json(resp);
        //}
        //public async Task<ActionResult> EditRole(int RoleID)
        //{
        //    ResponseModel resp = new ResponseModel();
        //    try
        //    {
        //        resp.Data = await _role.EditRole(RoleID);
        //        if (resp.Data != null)
        //        {
        //            resp.IsSuccess = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resp.IsSuccess = false;
        //        resp.Msg = ex.Message;
        //    }
        //    return Json(resp);
        //}
        //public async Task<ActionResult> GetRole()
        //{
        //    ResponseModel resp = new ResponseModel();
        //    try
        //    {
        //        resp.Data = await _role.GetAllRole();
        //        if (resp.Data != null || resp.Data == null)
        //        {
        //            resp.IsSuccess = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resp.IsSuccess = false;
        //        resp.Msg = ex.Message;
        //    }
        //    return Json(resp);
        //}
        //public async Task<ActionResult> DeleteRole(int RoleID)
        //{
        //    ResponseModel resp = new ResponseModel();
        //    try
        //    {
        //        resp.Data = await _role.DeleteRole(RoleID, CurrenUser.UserID);
        //        if (resp.Data != null)
        //        {
        //            resp.IsSuccess = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resp.IsSuccess = false;
        //        resp.Msg = ex.Message;
        //    }
        //    return Json(resp);
        //}
    }
}