using FactoryManagement.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Interface.UIinterface
{
    public interface IStore
    {
        Task<string> SaveStore(ModelStore modelStore);
        Task<ModelStore> EditStore(int StoreID);
        Task<IEnumerable<ModelStore>> GetAllStore();
        Task<int> DeleteStore(int StoreID, int UserID);
    }
}
