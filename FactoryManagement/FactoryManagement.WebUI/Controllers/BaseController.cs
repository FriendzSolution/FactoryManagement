using FactoryManagement.Common.Model;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace FactoryManagement.WebUI.Controllers
{
    public class BaseController : Controller
    {
        private ModelLogin model;
        public ModelLogin CurrenUser
        {
            get
            {
                string session = Convert.ToString(Session["User"]);
                if (session != null && session !="")
                {
                    model = JsonConvert.DeserializeObject<ModelLogin>(session);
                }
                return model;
            }
            set
            {
                model = value;
            }
        }
    }
}