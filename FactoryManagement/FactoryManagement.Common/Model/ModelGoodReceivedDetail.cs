using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Common.Model
{
    public class ModelGoodReceivedDetail
    {
        public int ReceivedDetailID { get; set; }
        public int? fk_ReceivedID { get; set; }
        public int? fk_DesignID { get; set; }
        public int? fk_SizeID { get; set; }
        public double? Quantity { get; set; }
        public double? Rate { get; set; }
        public double? Amount { get; set; }
        public int? fk_CompanyID { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }


        //User Define properties
        public string DesignTitle { get; set; }
        public string SizeTitle { get; set; }
    }
}
