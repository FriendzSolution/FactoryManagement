using System;
using System.Data;
using System.IO;
using System.Text;

namespace FactoryManagement.Common.Utilities
{
    public static class LoggerUtils
    {
        private static StringBuilder Message { get; set; } = new StringBuilder();
        public static string Replace(string str)
        {
            string a = "";
            if (str != null && str != "")
            {
                a = str.Replace("'", "''");

            }
            return a;
        }
        public static void WriteToFile(string Message)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }

        public static void WriteFullMsg(string msg)
        {
            Message.Append(msg);
            Message.Append(Environment.NewLine);
        }

        public static void Open(string Heading)
        {
            WriteFullMsg("=========================================================================================");
            WriteFullMsg(Heading);
            WriteFullMsg("=========================================================================================");
            WriteFullMsg("Date / Time........ " + DateTime.Now.ToString());
            WriteFullMsg("User............... " + Environment.UserDomainName + "\\" + Environment.UserName);
            WriteFullMsg("Machine............ " + Environment.MachineName);
            WriteFullMsg("OS Version......... " + Environment.OSVersion);
            WriteFullMsg("User Interactive... " + "True");
            WriteFullMsg("CLR Version........ " + Environment.Version);
            WriteFullMsg("Current Directory.. " + Environment.CurrentDirectory);
            WriteFullMsg("System Directory... " + Environment.SystemDirectory);
            WriteFullMsg("=========================================================================================");
            WriteFullMsg("");
            WriteFullMsg("");
        }

        public static void WriteCurrentRecord(DataTable dt, string Heading)
        {
            DataTable dr1 = dt;
            WriteFullMsg("=========================================================================================");
            WriteFullMsg(Heading);
            WriteFullMsg("=========================================================================================");
            foreach (DataRow row in dr1.Rows)
            {
                foreach (DataColumn column in dr1.Columns)
                {
                    string ColumnName = column.ColumnName;
                    string ColumnData = row[column].ToString();
                    if (ColumnName == "SystemSMTPServerPassword" || ColumnName == "SystemPOP3ServerPassword")
                    {
                        ColumnData = "************";
                    }
                    if (ColumnData == null || ColumnData == "")
                    {
                        ColumnData = "(null)";
                    }
                    string res = Replace("|  " + ColumnName.PadRight(30, '.').Substring(0, 29) + " " + ColumnData);
                    WriteFullMsg(res);
                }
            }
            WriteFullMsg("=========================================================================================");
            WriteFullMsg("");
            WriteFullMsg("");
        }


        public static string SaveLog()
        {
            string a = Message.ToString();
            return Message.ToString();
        }
    }
}
