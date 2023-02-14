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
    public class Unit : BaseClass, IUnit
    {
        private IDB _db;
        public Unit()
        {
            _db = new DB();
        }

        public async Task<int> DeleteUnit(int UnitID, int UserID)
        {
            if (UnitID != null)
            {
                string Query = "update tblUnit set IsDeleted='1',Deleteddate='" + DateTime.Now + "',DeletedBy='" + UserID + "'  where Unitid='" + UnitID + "'";
                _db.ExecuteNonQuery(Query);
            }
            return 1;
        }

        public async Task<ModelUnit> EditUnit(int UnitID)
        {
            try
            {
                ModelUnit modelUnit = new ModelUnit();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblUnit where Unitid='" + UnitID + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        modelUnit.UnitID = Convert.ToInt32(dr["UnitID"]);
                        modelUnit.UnitTitle = Convert.ToString(dr["UnitTitle"]);
                        modelUnit.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    }
                    _db.ConClose();
                    return modelUnit;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ModelUnit>> GetAllUnit()
        {
            try
            {
                List<ModelUnit> lstUnit = new List<ModelUnit>();
                _db.Conopen();
                SqlDataReader dr = _db.ExecuteQuery("select * from tblUnit where IsDeleted =0 and fk_CompanyId=1");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ModelUnit modelUnit = new ModelUnit();
                        modelUnit.UnitID = Convert.ToInt32(dr["UnitID"]);
                        modelUnit.UnitTitle = Convert.ToString(dr["UnitTitle"]);
                        modelUnit.IsActive = Convert.ToBoolean(dr["isActive"]);
                        modelUnit.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                        lstUnit.Add(modelUnit);
                    }
                    _db.ConClose();
                    return lstUnit;
                }
                _db.ConClose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveUnit(ModelUnit modelUnit)
        {
            try
            {
                if (modelUnit.UnitID != 0)
                {
                    string Query = "update tblUnit set UnitTitle='" + modelUnit.UnitTitle + "',IsActive='" + modelUnit.IsActive + "',modifyby='" + modelUnit.ModifyBy + "',ModifyDate='" + DateTime.Now + "' where Unitid='" + modelUnit.UnitID + "'";
                    _db.ExecuteNonQuery(Query);
                    return "Update Successfully";
                }
                else
                {
                    var UnitID = _db.getMaxID("Unitid", "tblUnit");
                    string Query = "insert into tblUnit (Unitid,TranDate,UnitTitle,IsActive,fk_Companyid,CreatedBy,CreatedDate,ModifyDate,Deleteddate) values(" + UnitID + ",'" + DateTime.Now + "','" + modelUnit.UnitTitle + "','" + modelUnit.IsActive + "','" + modelUnit.fk_Companyid + "','" + modelUnit.CreatedBy + "','" + DateTime.Now + "',null,null)";
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
