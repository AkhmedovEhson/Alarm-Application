using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Errors
{
    public struct ErrorType
    {
        public ErrorType(string? Type, string Message)
        {
            this.Type = Type ?? "Exception.Type";
            this.Message = Message;
        }
        public string Type { get;set; }
        public string Message { get;set; }
    }
}
