using FactoryManagement.Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                string session = Session["User"].ToString();
                if (session != null)
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