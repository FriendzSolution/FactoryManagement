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
    public class Store : BaseClass, IStore
    {
        private IDB _db;
        public Store()
        {
            _db = new DB();
        }

        public async Task<int> DeleteStore(int StoreID, int UserID)
        {
            if (StoreID != null)
            {
                string Query = "update tblStore set IsDeleted='1',Deleteddate='" + DateTime.Now + "',DeletedBy='" + UserID + "'  where Storeid='" + StoreID + "'";
                _db.ExecuteNonQuery(Query);
            }
            return 1;
        }

        public async Task<ModelStore> EditStore(int StoreID)
        {
            try
            {
                ModelStore modelStore = new ModelStore();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblStore where Storeid='" + StoreID + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        modelStore.StoreID = Convert.ToInt32(dr["StoreID"]);
                        modelStore.StoreTitle = Convert.ToString(dr["StoreTitle"]);
                        modelStore.StoreAddress = Convert.ToString(dr["StoreAddress"]);
                        modelStore.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    }
                    _db.ConClose();
                    return modelStore;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ModelStore>> GetAllStore()
        {
            try
            {
                List<ModelStore> lstStore = new List<ModelStore>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblStore where IsDeleted =0 and fk_CompanyId=1");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelStore modelStore = new ModelStore();
                        modelStore.StoreID = Convert.ToInt32(dr["StoreID"]);
                        modelStore.StoreTitle = Convert.ToString(dr["StoreTitle"]);
                        modelStore.StoreAddress = Convert.ToString(dr["StoreAddress"]);
                        modelStore.IsActive = Convert.ToBoolean(dr["isActive"]);
                        modelStore.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        lstStore.Add(modelStore);
                    }
                    _db.ConClose();
                    return lstStore;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveStore(ModelStore modelStore)
        {
            try
            {
                if (modelStore.StoreID != 0)
                {
                    string Query = "update tblStore set StoreTitle='" + modelStore.StoreTitle + "',StoreAddress='" + modelStore.StoreAddress + "',IsActive='" + modelStore.IsActive + "',modifyby='" + modelStore.ModifyBy + "',ModifyDate='" + DateTime.Now + "' where Storeid='" + modelStore.StoreID + "'";
                    _db.ExecuteNonQuery(Query);
                    return "Update Successfully";
                }
                else
                {
                    var StoreID = _db.getMaxID("Storeid", "tblStore");
                    string Query = "insert into tblStore (Storeid,TranDate,StoreTitle,StoreAddress,IsActive,fk_Companyid,CreatedBy,CreatedDate,ModifyDate,Deleteddate) values(" + StoreID + ",'" + DateTime.Now + "','" + modelStore.StoreTitle + "','" + modelStore.StoreAddress + "','" + modelStore.IsActive + "','" + modelStore.fk_CompanyID + "','" + modelStore.CreatedBy + "','" + DateTime.Now + "',null,null)";
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
