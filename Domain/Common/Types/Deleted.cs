using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Types
{
    public struct Deleted
    {
        public int Id { get; set; }
        public Deleted(int Id) => this.Id = Id;
    }
}
