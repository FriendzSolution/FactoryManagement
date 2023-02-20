using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Common.Model
{
    public class ModelDropdowns
    {
        public IEnumerable<ModelSupplier> GetSuppliers { get; set; }
        public IEnumerable<ModelStore> GetStores { get; set; }
        public IEnumerable<ModelDesignHead> GetDesignHeads { get; set; }
        public IEnumerable<ModelSize> GetSizes { get; set; }

    }
}
