using FactoryManagement.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Interface.UIinterface
{
    public interface IStoreRights
    {
        Task<ModelDropdowns> GetDropdowns();
        Task<string> SaveStoreRights(ModelStoreRights StoreRights);
        Task<ModelStoreRights> EditStoreRights(int TranID);
        Task<IEnumerable<ModelStoreRights>> GetAllStoreRights();
        Task<int> DeleteStoreRights(int TranID, int UserID);
    }
}
