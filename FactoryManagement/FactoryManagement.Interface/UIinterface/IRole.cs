using FactoryManagement.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Interface.UIinterface
{
    public interface IRole
    {
        Task<string> SaveRole(ModelRole modelRole);
        Task<ModelRole> EditRole(int RoleID);
        Task<IEnumerable<ModelRole>> GetAllRole();
    }
}
