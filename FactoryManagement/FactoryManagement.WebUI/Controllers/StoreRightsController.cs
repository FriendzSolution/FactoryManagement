using FactoryManagement.Common;
using FactoryManagement.Common.Model;
using FactoryManagement.Interface.UIinterface;
using FactoryManagement.Repository.UIRepo;
using FactoryManagement.WebUI.CustomAttribute;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.Controllers
{
    public class StoreRightsController : BaseController
    {
        private IStoreRights _StoreRights;
        public StoreRightsController()
        {
            _StoreRights = new StoreRights();
        }
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
                resp.Data = await _StoreRights.GetDropdowns();
                if (resp.Data != null)
                {
                    resp.IsSuccess = true;
                }
                else
                {
                    resp.IsSuccess = false;
                    resp.Msg = "No Row found..!!";
                }
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.Msg = ex.Message;
            }
            return Json(resp, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SaveRight(ModelStoreRights modelStoreRights)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                modelStoreRights.CreatedBy = CurrenUser.UserID;
                modelStoreRights.ModifyBy = CurrenUser.UserID;
                modelStoreRights.fk_CompanyID = 1;
                resp.Data = await _StoreRights.SaveStoreRights(modelStoreRights);
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
        public async Task<ActionResult> GetStoreRights()
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _StoreRights.GetAllStoreRights();
                if (resp.Data != null || resp.Data == null)
                {
                    resp.IsSuccess = true;
                }

            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
                resp.Msg = ex.Message;
            }
            return Json(resp);
        }
        public async Task<ActionResult> DeleteStoreRights(int RightsID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _StoreRights.DeleteStoreRights(RightsID, CurrenUser.UserID);
                if (resp.Data != null)
                {
                    resp.IsSuccess = true;
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