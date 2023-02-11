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
    public class Role : BaseClass, IRole
    {
        private IDB _db;
        public Role()
        {
            _db = new DB();
        }
        public Task<ModelRole> EditRole(int RoleID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ModelRole>> GetAllRole()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveRole(ModelRole modelRole)
        {
            try
            {
                string Query = "insert into tblrole (RoleName,IsActive,CreatedBy,CreatedDate) values('" + modelRole.RoleName + "','" + modelRole.IsActive + "','" + modelRole.CreatedBy + "','" + DateTime.Now + "')";
                _db.ExecuteNonQuery(Query);
                return "Save Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
