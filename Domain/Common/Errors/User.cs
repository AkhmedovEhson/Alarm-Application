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

            public static ErrorType UsernameNotFound => new ErrorType("User.UsernameNotFound", "User with provided username does not exist");
            public static ErrorType WrongPassword => new ErrorType("User.WrongPassword","Provided password is wrong");
        }
    }
}
