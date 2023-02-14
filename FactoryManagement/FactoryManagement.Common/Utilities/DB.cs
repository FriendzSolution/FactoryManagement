using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FactoryManagement.Common.Utilities
{
    public class DB : IDB
    {

        // SqlCommand cmd;

        SqlConnection con;
        public DB()
        {
            // con = new SqlConnection();
        }

        public void Conopen()
        {
            con = new SqlConnection(Utility.ConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        public void ConClose()
        {
            if (con.State == ConnectionState.Open)
            {
                //sometime close is throwing thread abort so need to supress it
                try
                {
                    con.Close();
                }
                catch (Exception ex) { }
            }
        }
        public SqlDataReader ExecuteQuery(string Query)
        {
            SqlCommand cmd = new SqlCommand(Query, con);
            //cmd.CommandTimeout = 180;

            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
        public void ExecuteNonQuery(string Query)
        {
            Conopen();
            SqlCommand cmd = new SqlCommand(Query, con);
            //cmd.CommandTimeout = 180;
            cmd.ExecuteNonQuery();
            ConClose();
            con.Dispose();
        }
        public DataSet GetDataSet(string Query)
        {
            con = new SqlConnection(Utility.ConnectionString);
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandTimeout = 180;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);
            con.Dispose();
            return dt;
        }
        public DataTable GetDatatable(string Query)
        {
            con = new SqlConnection(Utility.ConnectionString);
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandTimeout = 180;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Dispose();
            return dt;
        }
        public SqlDataAdapter GetDataAdapter(string Query)
        {
            con = new SqlConnection(Utility.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            //con.Dispose();
            return da;
        }
        public string GetNewID(string Query)
        {
            string ID = "";
            Conopen();
            SqlDataReader dr = ExecuteQuery(Query);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ID = dr[0].ToString();
                }
            }
            ConClose();
            con.Dispose();
            return ID;
        }
        public string Replace(string str)
        {
            string a = "";
            if (str != null && str != "")
            {
                a = str.Replace("'", "''");

            }
            return a;
        }
        public bool Checkstring(string str)
        {
            bool Validatestr = false;
            IEnumerable<string> codes = new List<string> { "A", "B","C", "D","E", "F","G", "H",
                                                           "I", "J","K", "L","M", "N","O", "P",
                                                           "Q", "R","S", "T","U", "V","W", "X",
                                                           "Y", "Z","a", "b","c", "d","e", "f","g", "h",
                                                           "i", "j","k", "l","m", "n","o", "p",
                                                           "q", "r","s", "t","u", "v","w", "x",
                                                           "y", "z"};
            bool match = codes.Contains(str);
            if (match == true)
            {
                Validatestr = true;
            }
            else
            {
                Validatestr = false;
            }
            return Validatestr;
        }
        public bool Checkint(int num)
        {
            bool Validateint = false;
            IEnumerable<int> codes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            bool match = codes.Contains(num);
            if (match == true)
            {
                Validateint = true;
            }
            else
            {
                Validateint = false;
            }
            return Validateint;
        }

        public void ExecuteNonQuery(string Query, params SqlParameter[] para)
        {
            con = new SqlConnection(Utility.ConnectionString);
            using (SqlConnection con_ = con)
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    foreach (var item in para)
                    {
                        cmd.Parameters.Add(item);
                    }
                    con_.Open();
                    cmd.ExecuteNonQuery();
                    con_.Close();
                    con.Dispose();
                }
            }
        }
        public string getMaxID(string id, string tblname)
        {
            return GetNewID("select isnull(max(" + id + "),0)+1 as id from " + tblname + " ");
        }
    }
}
