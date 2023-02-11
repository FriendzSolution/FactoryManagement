﻿using FactoryManagement.Common;
using FactoryManagement.Interface.UIinterface;
using FactoryManagement.Repository.UIRepo;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.Controllers
{
    public class UserController : BaseController
    {
        private IUser _user;
        public UserController()
        {
            _user = new User();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }


        public async Task<ActionResult> GetAllUsers()
        {
            ResponseModel resp = new ResponseModel();
            try
            {
                resp.Data = await _user.GetAllUser();
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