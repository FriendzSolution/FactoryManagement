using FactoryManagement.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Interface.UIinterface
{
    public interface IGoodReceived
    {
        Task<IEnumerable<ModelSupplier>> GetSuppliers();
        Task<IEnumerable<ModelStore>> GetStores();
        Task<IEnumerable<ModelDesignHead>> GetDesignHeads();
        Task<IEnumerable<ModelSize>> GetSizes();

        Task<ModelDropdowns> GetDropdowns();
        Task<IEnumerable<ModelGoodReceivedHead>> GetReceivedHead();
        Task<int> AddGoodReceived(ModelGoodReceivedHead modelGoodReceivedHead, ModelGoodReceivedDetail modelGoodReceivedDetail);
        Task<IEnumerable<ModelGoodReceivedDetail>> GetReceivedDetailsByID(int fk_ReceivedID);
        Task<ModelGoodReceivedHead> GetReceivedHeadByID(int ReceivedID);



    }
}
