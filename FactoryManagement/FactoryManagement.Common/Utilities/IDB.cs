using System.Data.SqlClient;
using System.Data;

namespace FactoryManagement.Common.Utilities
{
    public interface IDB
    {
        SqlDataReader ExecuteQuery(string Query);
        void ExecuteNonQuery(string Query);
        void ExecuteNonQuery(string Query, params SqlParameter[] para);
        DataSet GetDataSet(string Query);
        DataTable GetDatatable(string Query);
        SqlDataAdapter GetDataAdapter(string Query);
        string GetNewID(string Query);
        string getMaxID(string id, string tblname);

        string Replace(string str);
        bool Checkstring(string str);
        bool Checkint(int num);
        void Conopen();
        void ConClose();
    }
}
