using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alarm.Commands
{
    public static class Validations
    {
        public static bool RestrictRingAt(DateTime time)
        {
            if (time < DateTime.Now)
            {
                return false;
            }
            return true;

        }
    }
}
