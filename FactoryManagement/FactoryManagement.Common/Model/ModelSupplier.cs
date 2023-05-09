using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Common.Model
{
    public  class ModelSupplier
    {
        public int SupplierID { get; set; }

        public DateTime? Date { get; set; }

        public string SupplierTitle { get; set; }

        public string ContactNumber { get; set; }

        public string WhatsAppNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public bool? IsActive { get; set; }

        public int? fk_CompanyID { get; set; }

        public string BuisnessAddress { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool? IsDeleted { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
