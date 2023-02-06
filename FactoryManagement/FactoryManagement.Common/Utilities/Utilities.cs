using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace FactoryManagement.Common.Utilities
{
    public static class Utility
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["conMaxFashion"].ConnectionString.ToString();
        public static string Encrypt(string Password)
        {
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(Password)))
                    stringBuilder.Append(b.ToString("x2").ToLower());
                return stringBuilder.ToString();
            }
        }
    }


}