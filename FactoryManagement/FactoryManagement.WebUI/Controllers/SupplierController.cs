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
    public class SupplierController : BaseController
    {
        private ISupplier _Supplier;
        public SupplierController()
        {
            _Supplier = new Supplier();
        }
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetSupplier()
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _Supplier.GetAllSupplier();
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
            return Json(resp,JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SaveSupplier(ModelSupplier modelSupplier)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                modelSupplier.CreatedBy = CurrenUser.UserID;
                modelSupplier.ModifyBy = CurrenUser.UserID;
                modelSupplier.fk_CompanyID = 1;
                resp.Data = await _Supplier.SaveSupplier(modelSupplier);
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
        public async Task<ActionResult> EdirSupplier(int SupplierId)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _Supplier.EditSupplier(SupplierId);
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
        public async Task<ActionResult> DeleteSupplier(int SupplierId)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _Supplier.DeleteSupplier(SupplierId, CurrenUser.UserID);
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