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
    public class Size : BaseClass, ISize
    {
        private IDB _db;
        public Size()
        {
            _db = new DB();
        }

        public async Task<int> DeleteSize(int SizeID, int UserID)
        {
            if (SizeID != null)
            {
                string Query = "update tblSize set IsDeleted='1',Deleteddate='" + DateTime.Now + "',DeletedBy='" + UserID + "'  where Sizeid='" + SizeID + "'";
                _db.ExecuteNonQuery(Query);
            }
            return 1;
        }

        public async Task<ModelSize> EditSize(int SizeID)
        {
            try
            {
                ModelSize modelSize = new ModelSize();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblSize where Sizeid='" + SizeID + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        modelSize.SizeID = Convert.ToInt32(dr["SizeID"]);
                        modelSize.SizeTitle = Convert.ToString(dr["SizeTitle"]);
                        modelSize.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    }
                    _db.ConClose();
                    return modelSize;
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
                List<ModelSize> lstSize = new List<ModelSize>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblSize where IsDeleted =0 and fk_CompanyId=1");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelSize modelSize = new ModelSize();
                        modelSize.SizeID = Convert.ToInt32(dr["SizeID"]);
                        modelSize.SizeTitle = Convert.ToString(dr["SizeTitle"]);
                        modelSize.IsActive = Convert.ToBoolean(dr["isActive"]);
                        modelSize.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        lstSize.Add(modelSize);
                    }
                    _db.ConClose();
                    return lstSize;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveSize(ModelSize modelSize)
        {
            try
            {
                if (modelSize.SizeID != 0)
                {
                    string Query = "update tblSize set SizeTitle='" + modelSize.SizeTitle + "',IsActive='" + modelSize.IsActive + "',modifyby='" + modelSize.ModifyBy + "',ModifyDate='" + DateTime.Now + "' where Sizeid='" + modelSize.SizeID + "'";
                    _db.ExecuteNonQuery(Query);
                    return "Update Successfully";
                }
                else
                {
                    var SizeID = _db.getMaxID("Sizeid", "tblSize");
                    string Query = "insert into tblSize (Sizeid,TranDate,SizeTitle,IsActive,fk_Companyid,CreatedBy,CreatedDate,ModifyDate,Deleteddate) values(" + SizeID + ",'" + DateTime.Now + "','" + modelSize.SizeTitle + "','" + modelSize.IsActive + "','" + modelSize.fk_CompanyID + "','" + modelSize.CreatedBy + "','" + DateTime.Now + "',null,null)";
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
