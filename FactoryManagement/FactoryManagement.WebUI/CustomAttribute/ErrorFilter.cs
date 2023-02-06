using FactoryManagement.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.CustomAttribute
{
    public class ErrorFilter : Attribute
    {
        //public void OnException(ExceptionContext context)
        //{
        //    var services = context.HttpContext.RequestServices;
        //    var hostingEnv = (IWebHostEnvironment)services.GetService(typeof(IWebHostEnvironment));
        //    var exMessage = context.Exception.Message;
        //    var stackTrace = context.Exception.StackTrace;
        //    var controllerName = context.RouteData.Values["controller"].ToString();
        //    var actionName = context.RouteData.Values["action"].ToString();
        //    var Message = "Date : " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt") + " Error Message :" + exMessage + Environment.NewLine + "Stack Trace : " + stackTrace;
        //    StreamWriter log;
        //    FileStream fileStream = null;
        //    DirectoryInfo logDirInfo = null;
        //    FileInfo logFileInfo;
        //    string logFilePath = Path.Combine(hostingEnv.WebRootPath, context.HttpContext.RequestServices.GetService<IConfiguration>()["ExceptionLogPath"], "Log-" + System.DateTime.Today.ToString("dd-MMM-yyyy") + ".txt");
        //    // logFilePath += ;
        //    logFileInfo = new FileInfo(logFilePath);
        //    logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
        //    if (!logDirInfo.Exists)
        //    {
        //        logDirInfo.Create();
        //    }
        //    if (!logFileInfo.Exists)
        //    {
        //        fileStream = logFileInfo.Create();
        //    }
        //    else
        //    {
        //        fileStream = new FileStream(logFilePath, FileMode.Append);

        //    }
        //    log = new StreamWriter(fileStream);
        //    log.WriteLine("==========================Start-" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt") + "=============================");
        //    log.WriteLine("Log Created At-" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt") + Environment.NewLine + "Controller :" + controllerName + ", Action :" + actionName + ", Message :" + Message);
        //    log.WriteLine("==========================End-" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt") + "===============================");
        //    log.Close();
        //    if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //    {
        //        ResponseModel resp = new ResponseModel();
        //        resp.Msg = context.Exception.Message;
        //        resp.IsSuccess = false;
        //        context.Result = new JsonResult(resp);
        //    }
        //    else
        //    {
        //        context.Result = new RedirectResult("/Error/Index");
        //    }
        //}
    }
}