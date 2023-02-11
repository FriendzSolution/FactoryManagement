using FactoryManagement.Common;
using FactoryManagement.Common.Model;
using System;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.CustomAttribute
{
    public class AuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string userstring = Convert.ToString(filterContext.HttpContext.Session["User"]);
            ModelLogin user;
            if (!string.IsNullOrEmpty(userstring))
            {
                //if (!context.HttpContext.Request.Path.Value.ToLower().Contains("ViewReport"))
                //{

                //    if (context.HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
                //    {
                //        user = JsonConvert.DeserializeObject<ModelLogin>(userstring);
                //        if (!user.UserRights.Any(x => x.ScreenURL.ToLower() == context.HttpContext.Request.Path.Value.ToLower()))
                //        {
                //            context.Result = new RedirectResult("/Unauthorized");
                //        }
                //    }
                //}
            }
            else
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    ResponseModel resp = new ResponseModel();
                    resp.Msg = "session expired";
                    resp.IsSuccess = false;
                    var json = new JsonResult();
                    json.Data = resp;
                    json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    filterContext.Result = json;
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Login/Index");
                }
            }
        }
    }
}