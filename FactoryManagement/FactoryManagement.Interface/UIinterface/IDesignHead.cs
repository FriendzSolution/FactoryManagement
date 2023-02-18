
using FactoryManagement.Common.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryManagement.Interface.UIinterface
{
    public interface IDesignHead
    {
        Task<string> SaveDesignHead(ModelDesignHead modelDesignHead);
        Task<string> SaveDesignDetails(ModelDesignDetail modelDesignDetails);
        Task<ModelDesignHead> EditDesignHead(int DesignHeadID);
        Task<IEnumerable<ModelDesignHead>> GetAllDesignHead();
        Task<int> DeleteDesignHead(int DesignHeadID, int UserID);
        Task<IEnumerable<ModelSize>> GetAllSize();
    }
}
