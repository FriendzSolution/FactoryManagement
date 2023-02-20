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
    public class GoodReceived : IGoodReceived
    {
        private IDB _db;
        public GoodReceived()
        {
            _db = new DB();
        }
        public async Task<IEnumerable<ModelDesignHead>> GetDesignHeads()
        {
            try
            {
                List<ModelDesignHead> listDesignHeads = new List<ModelDesignHead>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select DesignID,DesignTitle from tblDesignHead where fk_Companyid =1 and isActive=1 and IsDeleted =0");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelDesignHead modelDesign = new ModelDesignHead();
                        modelDesign.DesignID = Convert.ToInt32(dr["DesignID"]);
                        modelDesign.DesignTitle = Convert.ToString(dr["DesignTitle"]);
                        listDesignHeads.Add(modelDesign);
                    }
                    _db.ConClose();
                    return listDesignHeads;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ModelSize>> GetSizes()
        {
            try
            {
                List<ModelSize> listSize = new List<ModelSize>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select SizeId,SizeTitle from tblsize where fk_Companyid =1 and isActive=1 and IsDeleted=0");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelSize modelSize = new ModelSize();
                        modelSize.SizeID = Convert.ToInt32(dr["SizeID"]);
                        modelSize.SizeTitle = Convert.ToString(dr["SizeTitle"]);
                        listSize.Add(modelSize);
                    }
                    _db.ConClose();
                    return listSize;
                }
                _db.ConClose();
                return null;
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

        public async Task<IEnumerable<ModelSupplier>> GetSuppliers()
        {
            try
            {
                List<ModelSupplier> listSuppliers = new List<ModelSupplier>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select SupplierID,SupplierTitle from tblSupplier where fk_Companyid =1 and isActive=1 and IsDeleted=0");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelSupplier modelSupplier = new ModelSupplier();
                        modelSupplier.SupplierID = Convert.ToInt32(dr["SupplierID"]);
                        modelSupplier.SupplierTitle = Convert.ToString(dr["SupplierTitle"]);
                        listSuppliers.Add(modelSupplier);
                    }
                    _db.ConClose();
                    return listSuppliers;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ModelDropdowns> GetDropdowns()
        {
            try
            {
                ModelDropdowns modelDropdowns = new ModelDropdowns();
                modelDropdowns.GetDesignHeads = await GetDesignHeads();
                modelDropdowns.GetSizes = await GetSizes();
                modelDropdowns.GetStores = await GetStores();
                modelDropdowns.GetSuppliers = await GetSuppliers();
                return modelDropdowns;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddGoodReceived(ModelGoodReceivedHead modelGoodReceivedHead, ModelGoodReceivedDetail modelGoodReceivedDetail)
        {
            try
            {

                var ReceivedID = modelGoodReceivedHead.ReceivedID;
                string strGoodReceivedHead = string.Empty;
                if (ReceivedID == 0)
                {
                    ReceivedID = Convert.ToInt32(_db.getMaxID("ReceivedID", "tblGoodReceivedHead"));
                    strGoodReceivedHead = "Insert into tblGoodReceivedHead (ReceivedID,Date,Description,fk_SupplierID,fk_CompanyID,fk_StoreID,CreatedBy,CreatedDate,ModifyBy,ModifyDate,IsDeleted,DeletedBy,DeletedDate)";
                    strGoodReceivedHead += "values(" + ReceivedID + ",'" + DateTime.Now + "',NULL,'" + modelGoodReceivedHead.fk_SupplierID + "','" + modelGoodReceivedHead.fk_CompanyID + "','" + modelGoodReceivedHead.fk_StoreID + "','" + modelGoodReceivedHead.CreatedBy + "','" + DateTime.Now + "',NULL,NULL,0,NULL,NULL)";
                }
                else
                {
                    strGoodReceivedHead = "Update tblGoodReceivedHead set ";
                    strGoodReceivedHead += "Date='" + DateTime.Now + "',";
                    strGoodReceivedHead += "Description=NULL,";
                    strGoodReceivedHead += "fk_SupplierID='" + modelGoodReceivedHead.fk_SupplierID + "',";
                    strGoodReceivedHead += "fk_StoreID='" + modelGoodReceivedHead.fk_StoreID + "',";
                    strGoodReceivedHead += "ModifyBy='" + modelGoodReceivedHead.ModifyBy + "',";
                    strGoodReceivedHead += "ModifyDate='" + DateTime.Now + "'";
                    strGoodReceivedHead += "Where ReceivedID=" + modelGoodReceivedHead.ReceivedID + "";
                }

                int ReceivedDetailID = modelGoodReceivedDetail.ReceivedDetailID;
                string strGoodReceivedDetail = string.Empty;
                if (ReceivedDetailID == 0)
                {
                    ReceivedDetailID = Convert.ToInt32(_db.getMaxID("ReceivedDetailID ", "tblGoodReceivedDetail"));
                    strGoodReceivedDetail = "Insert into tblGoodReceivedDetail (ReceivedDetailID,fk_ReceivedID,fk_DesignID,fk_SizeID,Quantity,Rate,Amount,fk_CompanyID,CreatedBy,CreatedDate,ModifyBy,ModifyDate,IsDeleted,DeletedBy,DeletedDate)";
                    strGoodReceivedDetail += "values(" + ReceivedDetailID + "," + ReceivedID + "," + modelGoodReceivedDetail.fk_DesignID + "," + modelGoodReceivedDetail.fk_SizeID + ",'" + modelGoodReceivedDetail.Quantity + "','" + modelGoodReceivedDetail.Rate + "','" + (modelGoodReceivedDetail.Quantity * modelGoodReceivedDetail.Rate) + "','" + modelGoodReceivedDetail.fk_CompanyID + "','" + modelGoodReceivedDetail.CreatedBy + "','" + DateTime.Now + "',NULL,NULL,0,NULL,NULL)";
                }
                else
                {
                    strGoodReceivedDetail = "Update tblGoodReceivedDetail set";
                    strGoodReceivedDetail += "fk_DesignID='" + modelGoodReceivedDetail.fk_DesignID + "',";
                    strGoodReceivedDetail += "fk_SizeID='" + modelGoodReceivedDetail.fk_SizeID + "',";
                    strGoodReceivedDetail += "Quantity='" + modelGoodReceivedDetail.Quantity + "',";
                    strGoodReceivedDetail += "Rate='" + modelGoodReceivedDetail.Rate + "',";
                    strGoodReceivedDetail += "Amount='" + (modelGoodReceivedDetail.Quantity * modelGoodReceivedDetail.Rate) + "',";
                    strGoodReceivedDetail += "ModifyBy='" + modelGoodReceivedDetail.ModifyBy + "',";
                    strGoodReceivedDetail += "ModifyDate='" + DateTime.Now + "'";
                    strGoodReceivedDetail += "where ReceivedDetailID=@ReceivedDetailID";
                }
                _db.ExecuteNonQuery(strGoodReceivedHead);
                _db.ExecuteNonQuery(strGoodReceivedDetail);
                return ReceivedID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ModelGoodReceivedDetail>> GetReceivedDetailsByID(int fk_ReceivedID)
        {
            try
            {
                List<ModelGoodReceivedDetail> listGoodReceivedDetails = new List<ModelGoodReceivedDetail>();
                string strGoodReceivedDetail = "select ";
                strGoodReceivedDetail += "gr.*,d.DesignTitle,SizeTitle ";
                strGoodReceivedDetail += "from tblGoodReceivedDetail gr ";
                strGoodReceivedDetail += "JOin tblDesignHead d on d.DesignID = gr.fk_DesignID ";
                strGoodReceivedDetail += "Join tblSize s on s.SizeID = gr.fk_SizeID ";
                strGoodReceivedDetail += "where gr.fk_Companyid =1  and gr.IsDeleted=0 and fk_ReceivedID='" + fk_ReceivedID + "'";
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery(strGoodReceivedDetail);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelGoodReceivedDetail modelGoodReceivedDetail = new ModelGoodReceivedDetail();
                        modelGoodReceivedDetail.ReceivedDetailID = Convert.ToInt32(dr["ReceivedDetailID"]);
                        modelGoodReceivedDetail.fk_ReceivedID = Convert.ToInt32(dr["fk_ReceivedID"]);
                        modelGoodReceivedDetail.fk_DesignID = Convert.ToInt32(dr["fk_DesignID"]);
                        modelGoodReceivedDetail.fk_SizeID = Convert.ToInt32(dr["fk_SizeID"]);
                        modelGoodReceivedDetail.DesignTitle = Convert.ToString(dr["DesignTitle"]);
                        modelGoodReceivedDetail.SizeTitle = Convert.ToString(dr["SizeTitle"]);
                        modelGoodReceivedDetail.Quantity = Convert.ToDouble(dr["Quantity"]);
                        modelGoodReceivedDetail.Rate = Convert.ToDouble(dr["Rate"]);
                        modelGoodReceivedDetail.Amount = Convert.ToDouble(dr["Amount"]);
                        listGoodReceivedDetails.Add(modelGoodReceivedDetail);
                    }
                    _db.ConClose();
                    return listGoodReceivedDetails;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ModelGoodReceivedHead> GetReceivedHeadByID(int ReceivedID)
        {
            try
            {
                ModelGoodReceivedHead modelGoodReceivedHead = new ModelGoodReceivedHead();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblGoodReceivedHead where fk_Companyid =1  and IsDeleted=0 and ReceivedID='" + ReceivedID + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        modelGoodReceivedHead.ReceivedID = Convert.ToInt32(dr["ReceivedID"]);
                        modelGoodReceivedHead.fk_SupplierID = Convert.ToInt32(dr["fk_SupplierID"]);
                        modelGoodReceivedHead.fk_StoreID = Convert.ToInt32(dr["fk_StoreID"]);
                    }
                    _db.ConClose();
                    return modelGoodReceivedHead;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ModelGoodReceivedHead>> GetReceivedHead()
        {
            try
            {
                List<ModelGoodReceivedHead> listGoodReceivedHead = new List<ModelGoodReceivedHead>();
                string strGoodReceivedHead = "select ";
                strGoodReceivedHead += "ReceivedID,gr.Date,SupplierTitle,StoreTitle ";
                strGoodReceivedHead += " from tblGoodReceivedHead gr ";
                strGoodReceivedHead += " JOIN tblSupplier s on s.SupplierID = gr.fk_SupplierID ";
                strGoodReceivedHead += " JOin tblStore st on st.StoreID = gr.fk_StoreID ";
                strGoodReceivedHead += "where gr.fk_Companyid =1  and gr.IsDeleted=0 ";
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery(strGoodReceivedHead);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelGoodReceivedHead modelGoodReceivedHead = new ModelGoodReceivedHead();
                        modelGoodReceivedHead.ReceivedID = Convert.ToInt32(dr["ReceivedID"]);
                        modelGoodReceivedHead.Date = Convert.ToDateTime(dr["Date"]);
                        modelGoodReceivedHead.SupplierTitle = Convert.ToString(dr["SupplierTitle"]);
                        modelGoodReceivedHead.StoreTitle = Convert.ToString(dr["StoreTitle"]);
                        listGoodReceivedHead.Add(modelGoodReceivedHead);
                    }
                    _db.ConClose();
                    return listGoodReceivedHead;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


