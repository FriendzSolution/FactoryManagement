using FactoryManagement.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Interface.UIinterface
{
    public interface IUnit
    {
        Task<string> SaveUnit(ModelUnit modelRole);
        Task<ModelUnit> EditUnit(int UnitID);
        Task<IEnumerable<ModelUnit>> GetAllUnit();
        Task<int> DeleteUnit(int RoleID, int UserID);
    }
}
