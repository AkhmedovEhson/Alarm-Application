using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Errors
{
    public static partial class Errors
    {
        public static partial class Alarm
        {
            public static ErrorType NotFound => new ErrorType("Alarm.NotFound", "Alarm not found");
        }

    }
}
