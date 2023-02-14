using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Common.Model
{
    public class ModelUnit
    {
        public int UnitID { get; set; }
        public DateTime? TranDate { get; set; }
        public string UnitTitle { get; set; }
        public bool IsActive { get; set; }
        public int fk_Companyid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool IsDeletd { get; set; }
        public int DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
