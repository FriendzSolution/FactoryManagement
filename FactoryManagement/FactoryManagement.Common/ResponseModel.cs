using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryManagement.Common
{
    public class ResponseModel
    {
        public object Data { get; set; }
        public string Msg { get; set; }
        public bool IsSuccess { get; set; }
    }
}
