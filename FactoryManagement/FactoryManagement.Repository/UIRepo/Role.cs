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
    public class Role : BaseClass, IRole
    {
        private IDB _db;
        public Role()
        {
            _db = new DB();
        }

        public async Task<int> DeleteRole(int RoleID,int UserID)
        {
            if (RoleID != null)
            {
                string Query = "update tblrole set IsDeleted='1',Deleteddate='" + DateTime.Now + "',DeletedBy='" + UserID+ "'  where Roleid='" + RoleID + "'";
                _db.ExecuteNonQuery(Query);
            }
            return 1;
        }

        public async Task<ModelRole> EditRole(int RoleID)
        {
            try
            {
                ModelRole modelRole = new ModelRole();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblrole where Roleid='"+RoleID+"'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        modelRole.RoleID = Convert.ToInt32(dr["RoleID"]);
                        modelRole.RoleName = Convert.ToString(dr["RoleName"]);
                        modelRole.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    }
                    _db.ConClose();
                    return modelRole;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ModelRole>> GetAllRole()
        {
            try
            {
                List<ModelRole> lstrole = new List<ModelRole>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblrole where IsDeleted =0 and fk_CompanyId=1");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelRole modelrole = new ModelRole();
                        modelrole.RoleID = Convert.ToInt32(dr["RoleID"]);
                        modelrole.RoleName = Convert.ToString(dr["RoleName"]);
                        modelrole.IsActive = Convert.ToBoolean(dr["isActive"]);
                        modelrole.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        lstrole.Add(modelrole);
                    }
                    _db.ConClose();
                    return lstrole;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveRole(ModelRole modelRole)
        {
            try
            {
                if (modelRole.RoleID != 0)
                {
                    string Query = "update tblrole set RoleName='" + modelRole.RoleName + "',IsActive='" + modelRole.IsActive + "',modifyby='" + modelRole.ModifyBy + "',ModifyDate='" + DateTime.Now + "' where Roleid='" + modelRole.RoleID + "'";
                    _db.ExecuteNonQuery(Query);
                    return "Update Successfully";
                }
                else
                {
                    string Query = "insert into tblrole (RoleName,IsActive,fk_Companyid,CreatedBy,CreatedDate,ModifyDate,Deleteddate) values('" + modelRole.RoleName + "','" + modelRole.IsActive + "','" + modelRole.fk_Companyid + "','" + modelRole.CreatedBy + "','" + DateTime.Now + "',null,null)";
                    _db.ExecuteNonQuery(Query);
                    return "Save Successfully";
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
