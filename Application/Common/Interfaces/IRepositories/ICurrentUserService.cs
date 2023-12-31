using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.IRepositories
{
    public interface ICurrentUserService
    {
        public int GetId();        
        public string GetUserName();
        public string GetAlarms();
    }
}
