using FactoryManagement.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Interface.UIinterface
{
    public interface ISupplier
    {
        Task<string> SaveSupplier(ModelSupplier modelSupplier);
        Task<ModelSupplier> EditSupplier(int SupplierID);
        Task<IEnumerable<ModelSupplier>> GetAllSupplier();
        Task<int> DeleteSupplier(int SupplierID, int UserID);    
    }
}
