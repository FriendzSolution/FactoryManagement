
using System;

namespace FactoryManagement.Common.Model
{
    public  class DesignHead
    {
        public int DesignID { get; set; }
        public string DesignTitle { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int fk_CompanyID { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }

        public int MyProperty { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
