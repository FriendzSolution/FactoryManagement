using FactoryManagement.Common.Model;
using FactoryManagement.Common.Utilities;
using FactoryManagement.Interface.UIinterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Repository.UIRepo
{
    public class Login : BaseClass, ILogin
    {
        private IDB _db;
        public Login()
        {
            _db = new DB();
        }
        public async Task<ModelLogin> Validate(string Username, string Password)
        {
            try
            {
                ModelLogin modelLogin = new ModelLogin();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblUser where IsDeleted = 0 and UserName='" + Username + "' and UserPassword='" + Utility.Encrypt(Password) + "' ");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        modelLogin.UserID = Convert.ToInt32(dr["UserID"]);
                        modelLogin.UserName = Convert.ToString(dr["UserName"]);
                        modelLogin.isActive = Convert.ToBoolean(dr["isActive"]);
                    }
                    _db.ConClose();
                    return modelLogin;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
