using FactoryManagement.Common.Model;
using FactoryManagement.Common.Utilities;
using FactoryManagement.Interface.UIinterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FactoryManagement.Repository.UIRepo
{
    public class User : IUser
    {
        private IDB _db;
        public User()
        {
            _db = new DB();
        }
        public async Task<IEnumerable<ModelUser>> GetAllUser()
        {
            try
            {
                List<ModelUser> lstUser = new List<ModelUser>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblUser where IsDeleted = 0");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelUser modelUser = new ModelUser();
                        modelUser.UserID = Convert.ToInt32(dr["UserID"]);
                        modelUser.UserName = Convert.ToString(dr["UserName"]);
                        modelUser.UserPassword = Convert.ToString(dr["UserPassword"]);
                        modelUser.isActive = Convert.ToBoolean(dr["isActive"]);
                        modelUser.ModifyDate = Convert.ToDateTime(dr["ModifyDate"]);
                        lstUser.Add(modelUser);
                    }
                    _db.ConClose();
                    return lstUser;
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
