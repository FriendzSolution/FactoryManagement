using FactoryManagement.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Interface.UIinterface
{
    public interface ISize
    {
        Task<string> SaveSize(ModelSize modelSize);
        Task<ModelSize> EditSize(int SizeID);
        Task<IEnumerable<ModelSize>> GetAllSize();
        Task<int> DeleteSize(int SizeID, int UserID);
    }
}
