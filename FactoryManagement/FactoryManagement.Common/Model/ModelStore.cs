using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Common.Model
{
    public class ModelStore
    {
        public int StoreID { get; set; }

        public DateTime? TranDate { get; set; }

        public string StoreTitle { get; set; }

        public string StoreAddress { get; set; }

        public bool? IsActive { get; set; }

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
