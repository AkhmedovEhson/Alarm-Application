using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ExceptionResult
    {
        public string Type { get; set; } = "";
        public string Message { get; set; } = "";
        public int StatusCode { get; set; }
    }
}
