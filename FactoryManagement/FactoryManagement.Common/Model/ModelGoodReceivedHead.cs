using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Common.Model
{
    public class ModelGoodReceivedHead
    {
        public int ReceivedID { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int? fk_SupplierID { get; set; }
        public int? fk_CompanyID { get; set; }
        public int? fk_StoreID { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        //User define Properties
        public string SupplierTitle { get; set; }
        public string StoreTitle { get; set; }

    }
}
