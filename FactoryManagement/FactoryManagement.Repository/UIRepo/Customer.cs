using FactoryManagement.Common.Model;
using FactoryManagement.Common.Utilities;
using FactoryManagement.Interface.UIinterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Repository.UIRepo
{
    public class Customer : BaseClass, ICustomer
    {
        private IDB _db;
        public Customer()
        {
            _db = new DB();
        }

        public async Task<int> DeleteCustomer(int CustomerID, int UserID)
        {
            if (CustomerID != null)
            {
                string Query = "update tblCustomer set IsDeleted='1',Deleteddate='" + DateTime.Now + "',DeletedBy='" + UserID + "'  where Customerid='" + CustomerID + "'";
                _db.ExecuteNonQuery(Query);
            }
            return 1;
        }

        public async Task<ModelCustomer> EditCustomer(int CustomerID)
        {
            try
            {
                ModelCustomer modelCustomer = new ModelCustomer();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblCustomer where Customerid='" + CustomerID + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        modelCustomer.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                        modelCustomer.CustomerTitle = Convert.ToString(dr["CustomerTitle"]);
                        modelCustomer.CustomerAddress = Convert.ToString(dr["CustomerAddress"]);
                        modelCustomer.WhatsAppNumber = Convert.ToString(dr["WhatsAppNumber"]);
                        modelCustomer.CustomerEmail = Convert.ToString(dr["CustomerEmail"]);
                        modelCustomer.CustomerCNIC = Convert.ToString(dr["CustomerCNIC"]);
                        modelCustomer.CustomerNumber = Convert.ToString(dr["CustomerNumber"]);
                        modelCustomer.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        modelCustomer.IsCreditAllowed = Convert.ToBoolean(dr["IsCreditAllowed"]);
                    }
                    _db.ConClose();
                    return modelCustomer;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ModelCustomer>> GetAllCustomer()
        {
            try
            {
                List<ModelCustomer> lstCustomer = new List<ModelCustomer>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblCustomer where IsDeleted =0 and fk_CompanyId=1");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelCustomer modelCustomer = new ModelCustomer();
                        modelCustomer.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                        modelCustomer.CustomerTitle = Convert.ToString(dr["CustomerTitle"]);
                        modelCustomer.CustomerAddress = Convert.ToString(dr["CustomerAddress"]);
                        modelCustomer.CustomerCNIC = Convert.ToString(dr["CustomerCNIC"]);
                        modelCustomer.CustomerNumber = Convert.ToString(dr["CustomerNumber"]);
                        modelCustomer.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        modelCustomer.IsCreditAllowed = Convert.ToBoolean(dr["IsCreditAllowed"]);
                        modelCustomer.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        lstCustomer.Add(modelCustomer);
                    }
                    _db.ConClose();
                    return lstCustomer;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveCustomer(ModelCustomer modelCustomer)
        {
            try
            {
                if (modelCustomer.CustomerID != 0)
                {
                    string Query = "update tblCustomer set CustomerTitle='" + modelCustomer.CustomerTitle + "',CustomerEmail='" + modelCustomer.CustomerEmail + "',WhatsAppNumber='" + modelCustomer.WhatsAppNumber + "',CustomerCNIC='" + modelCustomer.CustomerCNIC + "',CustomerNumber='" + modelCustomer.CustomerNumber + "',CustomerAddress='" + modelCustomer.CustomerAddress + "',IsCreditAllowed='" + modelCustomer.IsCreditAllowed + "',IsActive='" + modelCustomer.IsActive + "',modifyby='" + modelCustomer.ModifyBy + "',ModifyDate='" + DateTime.Now + "' where Customerid='" + modelCustomer.CustomerID + "'";
                    _db.ExecuteNonQuery(Query);
                    return "Update Successfully";
                }
                else
                {
                    var CustomerID = _db.getMaxID("Customerid", "tblCustomer");
                    string Query = "insert into tblCustomer (CustomerID,TranDate,CustomerTitle,CustomerCNIC,CustomerNumber,WhatsAppNumber,CustomerEmail,CustomerAddress,IsActive,IsCreditAllowed,fk_Companyid,CreatedBy,CreatedDate,ModifyDate,Deleteddate) values(" + CustomerID + ",'" + DateTime.Now + "','" + modelCustomer.CustomerTitle + "','" + modelCustomer.CustomerCNIC + "','" + modelCustomer.CustomerNumber + "','" + modelCustomer.WhatsAppNumber + "','" + modelCustomer.CustomerEmail + "','" + modelCustomer.CustomerAddress + "','" + modelCustomer.IsActive + "','" + modelCustomer.IsCreditAllowed + "','" + modelCustomer.fk_CompanyID + "','" + modelCustomer.CreatedBy + "','" + DateTime.Now + "',null,null)";
                    _db.ExecuteNonQuery(Query);
                    return "Save Successfully";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
