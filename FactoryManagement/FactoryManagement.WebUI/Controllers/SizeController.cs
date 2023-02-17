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
    [AuthorizationFilter]
    public class SizeController : BaseController
    {
        private ISize _size;
        public SizeController()
        {
            _size = new Size();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        //Main Grid Data
        public async Task<ActionResult> GetSize()
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _size.GetAllSize();
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

        public async Task<ActionResult> SaveSize(ModelSize modelSize)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                modelSize.CreatedBy = CurrenUser.UserID;
                modelSize.ModifyBy = CurrenUser.UserID;
                modelSize.fk_CompanyID = 1;
                resp.Data = await _size.SaveSize(modelSize);
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
        public async Task<ActionResult> EditSize(int SizeID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _size.EditSize(SizeID);
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
        public async Task<ActionResult> DeleteSize(int SizeID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _size.DeleteSize(SizeID, CurrenUser.UserID);
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