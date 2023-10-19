using Domain.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class NotFoundException :Exception
    {
        public ErrorType ErrorType { get; set; }
        public NotFoundException():base() { }

        public NotFoundException(ErrorType errorType)
        {
            this.ErrorType = errorType;
        }
    }
}
