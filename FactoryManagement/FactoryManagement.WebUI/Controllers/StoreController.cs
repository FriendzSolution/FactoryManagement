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
    public class StoreController : BaseController
    {
        private IStore _Store;
        public StoreController()
        {
            _Store = new Store();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public async Task<ActionResult> GetStore()
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _Store.GetAllStore();
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

        public async Task<ActionResult> SaveStore(ModelStore modelStore)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                modelStore.CreatedBy = CurrenUser.UserID;
                modelStore.ModifyBy = CurrenUser.UserID;
                modelStore.fk_CompanyID = 1;
                resp.Data = await _Store.SaveStore(modelStore);
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
        public async Task<ActionResult> EditStore(int StoreID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _Store.EditStore(StoreID);
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
        public async Task<ActionResult> DeleteStore(int StoreID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _Store.DeleteStore(StoreID, CurrenUser.UserID);
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