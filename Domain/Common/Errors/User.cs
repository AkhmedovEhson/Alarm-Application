using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Errors
{
    public static partial class Errors
    {
        public static partial class User
        {
            public static ErrorType NotFound => new ErrorType("User.NotFound","User not found");
        }
    }
}
