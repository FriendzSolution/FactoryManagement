using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Common.Model
{
    public class ModelStoreRights
    {
        public int TranID { get; set; }

        public DateTime? TranDate { get; set; }

        public int? fk_StoreID { get; set; }

        public int? fk_UserID { get; set; }

        public int? fk_CompanyID { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool? IsDeleted { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        // For Show In Grid
        public string UserName { get; set; }
        public string StoreTitle { get; set; }
    }
}
