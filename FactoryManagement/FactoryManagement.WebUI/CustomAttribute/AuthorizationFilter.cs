using FactoryManagement.Common;
using FactoryManagement.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizationFilter : Attribute
    {
        // private string[] Role { get; set; }
        public AuthorizationFilter()
        {
            //this.Role = Role.Split(',');
        }
        //public void OnAuthorization(AuthorizationFilterContext context)
        //{
        //    string userstring = context.HttpContext.Session.GetString("User");
        //    ModelLogin? user;
        //    if (!string.IsNullOrEmpty(userstring))
        //    {
        //        //if (!context.HttpContext.Request.Path.Value.ToLower().Contains("ViewReport"))
        //        //{

        //        //    if (context.HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
        //        //    {
        //        //        user = JsonConvert.DeserializeObject<ModelLogin>(userstring);
        //        //        if (!user.UserRights.Any(x => x.ScreenURL.ToLower() == context.HttpContext.Request.Path.Value.ToLower()))
        //        //        {
        //        //            context.Result = new RedirectResult("/Unauthorized");
        //        //        }
        //        //    }
        //        //}
        //    }
        //    else
        //    {
        //        if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //        {
        //            ResponseModel resp = new ResponseModel();
        //            resp.Msg = "session expired";
        //            resp.IsSuccess = false;
        //            context.Result = new JsonResult(resp);
        //        }
        //        else
        //        {
        //            context.Result = new RedirectResult("/Login/Index");
        //        }
        //    }


        //}
    }
}