using FactoryManagement.Common.Model;
using FactoryManagement.Common.Utilities;
using FactoryManagement.Interface.UIinterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FactoryManagement.Repository.UIRepo
{
    public class DesignHead : BaseClass, IDesignHead
    {
        private IDB _db;
        public DesignHead()
        {
            _db = new DB();
        }
        public async Task<int> DeleteDesignHead(int DesignHeadID, int UserID)
        {
            if (DesignHeadID != null)
            {
                string Query = "update tbldesignhead set IsDeleted='1',Deleteddate='" + DateTime.Now + "',DeletedBy='" + UserID + "'  where Designid='" + DesignHeadID + "'";
                _db.ExecuteNonQuery(Query);
            }
            return 1;
        }

        public async Task<ModelDesignHead> EditDesignHead(int DesignHeadID)
        {
            try
            {
                ModelDesignHead modelDesignHead = new ModelDesignHead();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tbldesignhead where Designid='" + DesignHeadID + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        modelDesignHead.DesignID = Convert.ToInt32(dr["DesignID"]);
                        modelDesignHead.DesignTitle = Convert.ToString(dr["DesignTitle"]);
                        modelDesignHead.Description = Convert.ToString(dr["Description"]);
                        modelDesignHead.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    }
                    _db.ConClose();
                    return modelDesignHead;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ModelDesignHead>> GetAllDesignHead()
        {
            try
            {
                List<ModelDesignHead> lstDHead = new List<ModelDesignHead>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tbldesignhead where IsDeleted is null and fk_CompanyId=1");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelDesignHead modelhead = new ModelDesignHead();
                        modelhead.DesignID = Convert.ToInt32(dr["DesignID"]);
                        modelhead.DesignTitle = Convert.ToString(dr["DesignTitle"]);
                        modelhead.Description = Convert.ToString(dr["Description"]);
                        modelhead.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        modelhead.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        lstDHead.Add(modelhead);
                    }
                    _db.ConClose();
                    return lstDHead;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ModelSize>> GetAllSize()
        {
            try
            {
                List<ModelSize> lstDHead = new List<ModelSize>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select SizeId,SizeTitle from tblsize where fk_Companyid =1 and isActive=1 and IsDeleted=0");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelSize modelhead = new ModelSize();
                        modelhead.SizeID = Convert.ToInt32(dr["SizeID"]);
                        modelhead.SizeTitle = Convert.ToString(dr["SizeTitle"]);
                        lstDHead.Add(modelhead);
                    }
                    _db.ConClose();
                    return lstDHead;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveDesignDetails(ModelDesignDetail modelDesignDetails)
        {
            try
            {
               var DesignID = _db.getMaxID("DesignID", "tblDesignHead");
                string Query = "insert into tblDesignHead (DesignID,DesignTitle,Date,Description,IsActive,fk_Companyid,CreatedBy,CreatedDate,ModifyDate,Deleteddate,IsDeleted)" +
                      " values('" + DesignID + "','" + modelDesignDetails.DesignTitle + "','" + DateTime.Now + "','" + modelDesignDetails.Description + "','" + modelDesignDetails.IsActive + "','" + modelDesignDetails.fk_CompanyID + "','" + modelDesignDetails.CreatedBy + "','" + DateTime.Now + "',null,null,null)";
                _db.ExecuteNonQuery(Query);
                
                var DesignDeatilsID = _db.getMaxID("DesignDetailID", "tblDesignDetail");
                
                string Query2 = "insert into tblDesignDetail (DesignDetailID,fk_DesignID,fk_Size,CreatedBy,CreatedDate,ModifyDate,Deleteddate,IsDeleted)" +
                    " values('" + DesignDeatilsID + "','" + DesignID + "','" + modelDesignDetails.fk_Size + "','" + modelDesignDetails.CreatedBy + "','" + DateTime.Now + "',null,null,null)";
                _db.ExecuteNonQuery(Query2);
                return DesignID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveDesignHead(ModelDesignHead modelDesignHead)
        {
            try
            {
                if (modelDesignHead.DesignID != 0)
                {
                    string Query = "update tblDesignHead set DesignTitle='" + modelDesignHead.DesignTitle + "',Description='"+ modelDesignHead .Description+ "',IsActive='" + modelDesignHead.IsActive + "',modifyby='" + modelDesignHead.ModifyBy + "',ModifyDate='" + DateTime.Now + "' where DesignID='" + modelDesignHead.DesignID + "'";
                    _db.ExecuteNonQuery(Query);
                    return "Update Successfully";
                }
                else
                {
                    //string Query = "insert into tblDesignHead (DesignID,DesignTitle,Date,Description,IsActive,fk_Companyid,CreatedBy,CreatedDate,ModifyDate,Deleteddate,IsDeleted)" +
                    //    " values('"+ DesignID + "','" + modelDesignHead.DesignTitle + "','" + DateTime.Now + "','"+modelDesignHead.Description+"','"+modelDesignHead.IsActive+"','" + modelDesignHead.fk_CompanyID + "','" + modelDesignHead.CreatedBy + "','" + DateTime.Now + "',null,null,null)";
                    //_db.ExecuteNonQuery(Query);
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
