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
    public class UnitController : BaseController
    {
        private IUnit _unit;
        public UnitController()
        {
            _unit = new Unit();
        }
        // GET: Unit
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        //Main Grid Data
        public async Task<ActionResult> GetUnit()
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _unit.GetAllUnit();
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

        public async Task<ActionResult> SaveUnit(ModelUnit modelUnit)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                modelUnit.CreatedBy = CurrenUser.UserID;
                modelUnit.ModifyBy = CurrenUser.UserID;
                modelUnit.fk_Companyid = 1;
                resp.Data = await _unit.SaveUnit(modelUnit);
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
        public async Task<ActionResult> EditUnit(int UnitID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _unit.EditUnit(UnitID);
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
        public async Task<ActionResult> DeleteUnit(int UnitID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _unit.DeleteUnit(UnitID, CurrenUser.UserID);
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