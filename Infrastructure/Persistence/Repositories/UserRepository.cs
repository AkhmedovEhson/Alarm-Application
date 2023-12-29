using Application.Common.Interfaces.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository:Repository<UserEntity>,IUserRepository
    {
        private ApplicationDbContext ApplicationDbContext;
        public UserRepository(ApplicationDbContext db) : base(db) { ApplicationDbContext = db; }

        public Task<UserEntity?> FindAsync(string username)
        {
            return ApplicationDbContext.Users.Where(o => o.Username == username).FirstOrDefaultAsync();
        }

        public Task<UserEntity?> LoginAsync(string username, string password)
        {
            return ApplicationDbContext.Users.Where(o => o.Username == username && o.Password == password).FirstOrDefaultAsync();
        }

    }
}
