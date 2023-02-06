using FactoryManagement.Common.Model;
using FactoryManagement.Common.Utilities;
using FactoryManagement.Interface.UIinterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Repository.UIRepo
{
    public class Login : BaseClass, ILogin
    {
        //DB _db = new DB();
        private IDB _db;
        public Login(IDB db)
        {
            _db = db;
        }
        public async Task<ModelLogin> Validate()
        {
            try
            {
                ModelLogin modelLogin = new ModelLogin();
                var a = _db.GetNewID("select UserID from tblUser");
                return modelLogin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
