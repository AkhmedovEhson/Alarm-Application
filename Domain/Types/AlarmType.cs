using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types
{
    public class AlarmType
    {
        public string Day { get; set; } = string.Empty;
        public string Hour { get; set; } = string.Empty;
        public string Minute { get; set; } = string.Empty;
        public string Second { get; set; } = string.Empty;
    }
}
