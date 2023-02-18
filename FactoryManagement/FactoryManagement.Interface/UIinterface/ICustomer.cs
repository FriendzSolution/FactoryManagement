using FactoryManagement.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Interface.UIinterface
{
    public interface ICustomer
    {
        Task<string> SaveCustomer(ModelCustomer modelCustomer);
        Task<ModelCustomer> EditCustomer(int CustomerID);
        Task<IEnumerable<ModelCustomer>> GetAllCustomer();
        Task<int> DeleteCustomer(int CustomerID, int UserID);
    }
}
