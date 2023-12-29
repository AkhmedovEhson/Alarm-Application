using Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class PasswordException:Exception
    {
        public ErrorType ErrorType { get; set; }
        public PasswordException():base() { }

        public PasswordException(ErrorType errorType)
        {
            this.ErrorType = errorType;
        }
    }
}
