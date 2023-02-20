using FactoryManagement.Common;
using FactoryManagement.Common.Model;
using FactoryManagement.Interface.UIinterface;
using FactoryManagement.Repository.UIRepo;
using FactoryManagement.WebUI.CustomAttribute;
using Newtonsoft.Json;
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
                resp.Data = await _goodReceived.GetDropdowns();
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
        [HttpPost]
        public async Task<ActionResult> AddGoodReceived(ModelGoodReceivedHead modelGoodReceivedHead, ModelGoodReceivedDetail modelGoodReceivedDetail)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                modelGoodReceivedHead.CreatedBy = CurrenUser.UserID;
                modelGoodReceivedHead.ModifyBy = CurrenUser.UserID;
                modelGoodReceivedHead.fk_CompanyID = 1;
                modelGoodReceivedDetail.CreatedBy = CurrenUser.UserID;
                modelGoodReceivedDetail.ModifyBy = CurrenUser.UserID;
                modelGoodReceivedDetail.fk_CompanyID = 1;
                resp.Data = await _goodReceived.AddGoodReceived(modelGoodReceivedHead, modelGoodReceivedDetail);
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



        [HttpGet]
        public async Task<ActionResult> GetReceivedDetailsByID(int fk_ReceivedID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _goodReceived.GetReceivedDetailsByID(fk_ReceivedID);
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
        [HttpGet]
        public async Task<ActionResult> GetReceivedHeadByID(int ReceivedID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _goodReceived.GetReceivedHeadByID(ReceivedID);
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
        [HttpGet]
        public async Task<ActionResult> GetReceivedHead()
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _goodReceived.GetReceivedHead();
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
    }
}