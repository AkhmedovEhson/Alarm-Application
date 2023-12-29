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
        public Task<UserEntity?> FindAsync(string username); 
        public Task<UserEntity?> LoginAsync(string username, string password);
    }
}
