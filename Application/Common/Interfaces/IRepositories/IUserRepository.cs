using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.IRepositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
    }
}
