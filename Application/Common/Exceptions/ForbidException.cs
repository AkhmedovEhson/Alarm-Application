using Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class ForbidException: Exception
    {
        public ErrorType ErrorType { get; set; }
        public ForbidException(ErrorType errorType)
        {
            ErrorType = errorType;
        }

        public ForbidException():base() { }

        public ForbidException (string message) : base(message) { }
    }
}
