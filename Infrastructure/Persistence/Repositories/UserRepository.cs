using Application.Common.Interfaces.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository:Repository<UserEntity>,IUserRepository
    {
        public UserRepository(ApplicationDbContext db):base(db) { }
    }
}
