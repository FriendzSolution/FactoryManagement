
using System;

namespace FactoryManagement.Common.Model
{
    public  class ModelDesignHead
    {
        public int DesignID { get; set; }
        public string DesignTitle { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int fk_CompanyID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int IsDeleted { get; set; }
        public int DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
