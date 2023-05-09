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
    public class StoreRights : BaseClass, IStoreRights
    {
        private IDB _db;
        public StoreRights()
        {
            _db = new DB();
        }
        public async Task<ModelDropdowns> GetDropdowns()
        {
            try
            {
                ModelDropdowns modelDropdowns = new ModelDropdowns();
                modelDropdowns.GetStores = await GetStores();
                modelDropdowns.GetUserName = await GetUserName();
                return modelDropdowns;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<ModelStore>> GetStores()
        {
            try
            {
                List<ModelStore> listStore = new List<ModelStore>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select StoreID,StoreTitle from tblStore where fk_Companyid =1 and isActive=1 and IsDeleted=0");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelStore modelStore = new ModelStore();
                        modelStore.StoreID = Convert.ToInt32(dr["StoreID"]);
                        modelStore.StoreTitle = Convert.ToString(dr["StoreTitle"]);
                        listStore.Add(modelStore);
                    }
                    _db.ConClose();
                    return listStore;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IEnumerable<ModelUser>> GetUserName()
        {
            try
            {
                List<ModelUser> listStore = new List<ModelUser>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select UserID,UserName from tblUser where fk_Companyid =1 and isActive=1 and IsDeleted=0");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelUser modelStore = new ModelUser();
                        modelStore.UserID = Convert.ToInt32(dr["UserID"]);
                        modelStore.UserName = Convert.ToString(dr["UserName"]);
                        listStore.Add(modelStore);
                    }
                    _db.ConClose();
                    return listStore;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<int> DeleteStoreRights(int TranID, int UserID)
        {
            if (TranID != null)
            {
                string Query = "update tblStoreRights set IsDeleted='1',Deleteddate='" + DateTime.Now + "',DeletedBy='" + UserID + "'  where TranID='"+ TranID + "'";
                _db.ExecuteNonQuery(Query);
            }
            return 1;
        }

        public async Task<ModelStoreRights> EditStoreRights(int TranID)
        {
            try
            {
                ModelStoreRights model = new ModelStoreRights();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from [dbo].[tblStoreRights] where TranId='" + TranID + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //model.StoreID = Convert.ToInt32(dr["StoreID"]);
                        //model.StoreTitle = Convert.ToString(dr["StoreTitle"]);
                        //model.StoreAddress = Convert.ToString(dr["StoreAddress"]);
                        //model.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    }
                    _db.ConClose();
                    return model;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ModelStoreRights>> GetAllStoreRights()
        {
            try
            {
                string q = "select tblStoreRights.TranID,tblStoreRights.TranDate,tblUser.UserName,";
                q += Environment.NewLine + " tblStore.StoreTitle,tblStoreRights.CreatedDate from tblStoreRights";
                q += Environment.NewLine + " Join tblUser On tblUser.UserID = tblStoreRights.fk_UserID";
                q += Environment.NewLine + " Join tblStore On tblStore.StoreID = tblStoreRights.fk_StoreID";
                q += Environment.NewLine + " where tblStoreRights.IsDeleted =0 and tblStoreRights.fk_CompanyId=1";

                List<ModelStoreRights> lstStore = new List<ModelStoreRights>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery(q);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelStoreRights ModelStoreRights = new ModelStoreRights();
                        ModelStoreRights.TranID = Convert.ToInt32(dr["TranID"]);
                        ModelStoreRights.TranDate = Convert.ToDateTime(dr["TranDate"]);
                        ModelStoreRights.UserName = Convert.ToString(dr["UserName"]);
                        ModelStoreRights.StoreTitle = Convert.ToString(dr["StoreTitle"]);
                        ModelStoreRights.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        lstStore.Add(ModelStoreRights);
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

        public async Task<string> SaveStoreRights(ModelStoreRights modelStoreRights)
        {
            try
            {
                if (modelStoreRights.TranID != 0)
                {
                    string Query = "update tblStoreRights set fk_StoreID='" + modelStoreRights.fk_StoreID + "',fk_UserID='" + modelStoreRights.fk_UserID + "',modifyby='" + modelStoreRights.ModifyBy + "',ModifyDate='" + DateTime.Now + "' where TranID='" + modelStoreRights.TranID + "'";
                    _db.ExecuteNonQuery(Query);
                    return "Update Successfully";
                }
                else
                {
                    var RightID = _db.getMaxID("TranID", "tblStoreRights");
                    string Query = "insert into tblStoreRights (TranID,TranDate,fk_StoreID,fk_UserID,fk_Companyid,CreatedBy,CreatedDate,ModifyDate) values(" + RightID + ",'" + DateTime.Now + "','" + modelStoreRights.fk_StoreID + "','" + modelStoreRights.fk_UserID + "','" + modelStoreRights.fk_CompanyID + "','" + modelStoreRights.CreatedBy + "','" + DateTime.Now + "','" + DateTime.Now + "')";
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
