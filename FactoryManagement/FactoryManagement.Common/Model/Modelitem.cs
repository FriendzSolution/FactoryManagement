using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Common.Model
{
    public class Modelitem
    {
        public int ItemID { get; set; }

        public DateTime? TranDate { get; set; }

        public string ItemTitle { get; set; }

        public string Description { get; set; }

        public int fk_StoreID { get; set; }

        public int fk_DesignID { get; set; }

        public string fk_UnitID { get; set; }
        public decimal ItemRate { get; set; }

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
