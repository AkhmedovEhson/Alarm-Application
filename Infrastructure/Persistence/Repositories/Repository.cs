using Application.Common.Interfaces.IRepositories;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseAuditableEntity
    {
        private ApplicationDbContext ApplicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public IQueryable<T> GetValuesQueryable(bool byDescending = false)
        {
            if (byDescending)
            {
                return ApplicationDbContext.Set<T>().AsNoTracking().OrderByDescending(o => o.Id);
            }

            return ApplicationDbContext.Set<T>().AsNoTracking();

        }

        public ValueTask<T?> FindAsync(int id)
        {
            return ApplicationDbContext.Set<T>().FindAsync(id);
        }
        
        public async Task AddAsync(T data)
        {
            await ApplicationDbContext.AddAsync(data);  
            await ApplicationDbContext.SaveChangesAsync();  
        }
        public async Task Update(T data)
        {
            ApplicationDbContext.Set<T>().Update(data);
            await ApplicationDbContext.SaveChangesAsync();
        }
        public async Task Remove(T data)
        {
            ApplicationDbContext.Remove(data);
            await ApplicationDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Repository method, <seealso cref="RemoveId(int)"/> will remove entity by ID, if responses 1 : error, 0 is success
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> RemoveId(int id)
        {
            var entity = await ApplicationDbContext.Alarms.Where(o => o.Id == id).FirstAsync();

            if (entity == null)
            {
                return 1;
            }

            ApplicationDbContext.Remove(entity);

            await ApplicationDbContext.SaveChangesAsync();
            return 0;
        }
    }
}
