using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Types
{
    public struct Success
    {
        public Success(int Id) => this.Id = Id;
        public int Id { get; }
    }
}
