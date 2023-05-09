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
    public class Supplier : BaseClass, ISupplier
    {
        private IDB _db;
        public Supplier()
        {
            _db = new DB();
        }

        public async Task<int> DeleteSupplier(int SupplierID, int UserID)
        {
            if (SupplierID != null)
            {
                string Query = "update tblsupplier set IsDeleted='1',DeletedDate='" + DateTime.Now + "',DeletedBy='" + UserID + "'  where SupplierID='" + SupplierID + "'";
                _db.ExecuteNonQuery(Query);
            }
            return 1;
        }

        public async Task<ModelSupplier> EditSupplier(int SupplierID)
        {
            try
            {
                ModelSupplier modelSup = new ModelSupplier();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblsupplier where SupplierID='" + SupplierID + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        modelSup.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        modelSup.SupplierTitle = Convert.ToString(dr["SupplierTitle"]);
                        modelSup.ContactNumber = Convert.ToString(dr["ContactNumber"]);
                        modelSup.WhatsAppNumber = Convert.ToString(dr["WhatsAppNumber"]);
                        modelSup.Email = Convert.ToString(dr["Email"]);
                        modelSup.Address = Convert.ToString(dr["Address"]);
                        modelSup.BuisnessAddress = Convert.ToString(dr["BuisnessAddress"]);
                        modelSup.Date = Convert.ToDateTime(dr["Date"]);
                        modelSup.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    }
                    _db.ConClose();
                    return modelSup;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ModelSupplier>> GetAllSupplier()
        {
            try
            {
                List<ModelSupplier> lstSup = new List<ModelSupplier>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblsupplier where IsDeleted =0 and fk_CompanyId=1 order by supplierID DESC");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelSupplier modelSupplier = new ModelSupplier();
                        modelSupplier.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        modelSupplier.SupplierTitle = Convert.ToString(dr["SupplierTitle"]);
                        modelSupplier.ContactNumber = Convert.ToString(dr["ContactNumber"]);
                        modelSupplier.WhatsAppNumber = Convert.ToString(dr["WhatsAppNumber"]);
                        modelSupplier.Email = Convert.ToString(dr["Email"]);
                        modelSupplier.Address = Convert.ToString(dr["Address"]);
                        modelSupplier.BuisnessAddress = Convert.ToString(dr["BuisnessAddress"]);
                        modelSupplier.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        lstSup.Add(modelSupplier);
                    }
                    _db.ConClose();
                    return lstSup;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveSupplier(ModelSupplier modelSupplier)
        {
            try
            {
                if (modelSupplier.SupplierID != 0)
                {
                    string Query = "update tblsupplier set SupplierTitle='" + modelSupplier.SupplierTitle + "',ContactNumber='" + modelSupplier.ContactNumber + "'" +
                        ",WhatsAppNumber='" + modelSupplier.WhatsAppNumber + "',Email='" + modelSupplier.Email + "',Address='" + modelSupplier.Address + "',BuisnessAddress='" + modelSupplier.BuisnessAddress + "',Date='" + modelSupplier.Date + "',IsActive='" + modelSupplier.IsActive + "',modifyby='" + modelSupplier.ModifyBy + "'" +
                        ",ModifyDate='" + DateTime.Now + "' where SupplierID='" + modelSupplier.SupplierID + "'";
                    _db.ExecuteNonQuery(Query);
                    return "Update Successfully";
                }
                else
                {
                    var SupplierID = _db.getMaxID("SupplierID", "tblsupplier");
                    string Query = "insert into tblsupplier (SupplierID,Date,SupplierTitle,ContactNumber,WhatsAppNumber,Email,Address,BuisnessAddress,IsActive,fk_Companyid,CreatedBy,CreatedDate,ModifyDate,Deleteddate)" +
                        " values(" + SupplierID + ",'" + DateTime.Now + "','" + modelSupplier.SupplierTitle + "','" + modelSupplier.ContactNumber + "','" + modelSupplier.WhatsAppNumber + "','" + modelSupplier.Email + "'" +
                        ",'" + modelSupplier.Address + "','" + modelSupplier.BuisnessAddress + "','" + modelSupplier.IsActive + "'," +
                        "'" + modelSupplier.fk_CompanyID + "','" + modelSupplier.CreatedBy + "','" + DateTime.Now + "',null,null)";
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
