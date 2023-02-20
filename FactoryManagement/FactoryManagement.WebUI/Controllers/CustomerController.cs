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
    public class CustomerController : BaseController
    {
        private ICustomer _Customer;
        // GET: Customer
        public CustomerController()
        {
            _Customer = new Customer();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public async Task<ActionResult> GetCustomer()
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _Customer.GetAllCustomer();
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

        public async Task<ActionResult> SaveCustomer(ModelCustomer modelCustomer)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                modelCustomer.CreatedBy = CurrenUser.UserID;
                modelCustomer.ModifyBy = CurrenUser.UserID;
                modelCustomer.fk_CompanyID = 1;
                resp.Data = await _Customer.SaveCustomer(modelCustomer);
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
        public async Task<ActionResult> EditCustomer(int CustomerID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _Customer.EditCustomer(CustomerID);
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
        public async Task<ActionResult> DeleteCustomer(int CustomerID)
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _Customer.DeleteCustomer(CustomerID, CurrenUser.UserID);
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