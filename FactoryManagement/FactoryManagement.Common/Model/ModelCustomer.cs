using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Common.Model
{
    public class ModelCustomer
    {
        public int CustomerID { get; set; }

        public DateTime? TranDate { get; set; }

        public string CustomerTitle { get; set; }

        public string CustomerCNIC { get; set; }

        public string CustomerNumber { get; set; }
        public string WhatsAppNumber { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerAddress { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsCreditAllowed { get; set; }

        public int? fk_CompanyID { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool? IsDeleted { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
