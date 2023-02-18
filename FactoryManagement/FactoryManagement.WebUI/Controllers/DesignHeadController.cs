using FactoryManagement.Common;
using FactoryManagement.Common.Model;
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
    public class DesignHeadController : BaseController
    {
        private IDesignHead _designHead;
        public DesignHeadController()
        {
            _designHead = new DesignHead();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public async Task<ActionResult> SaveDesignHead(ModelDesignHead modelDesignHead)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                modelDesignHead.CreatedBy = CurrenUser.UserID;
                modelDesignHead.ModifyBy = CurrenUser.UserID;
                modelDesignHead.fk_CompanyID = 1;
                resp.Data = await _designHead.SaveDesignHead(modelDesignHead);
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
        public async Task<ActionResult> EditDesign(int DesignID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _designHead.EditDesignHead(DesignID);
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
        public async Task<ActionResult> GetDesignHead()
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _designHead.GetAllDesignHead();
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
        public async Task<ActionResult> DeleteDesignHead(int DesignId)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _designHead.DeleteDesignHead(DesignId,CurrenUser.UserID);
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
        public async Task<ActionResult> GetSize()
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _designHead.GetAllSize();
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
        public async Task<ActionResult> SaveDesignDetails(ModelDesignDetail modelDesignDetails)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                modelDesignDetails.CreatedBy = CurrenUser.UserID;
                modelDesignDetails.ModifyBy = CurrenUser.UserID;
                modelDesignDetails.fk_CompanyID = 1;
                resp.Data = await _designHead.SaveDesignDetails(modelDesignDetails);
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