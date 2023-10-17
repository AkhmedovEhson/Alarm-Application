using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class Repository<T> where T : class
    {
        private ApplicationDbContext ApplicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }
        
        public Task<List<T>> GetValuesAsync()
        {
            return ApplicationDbContext.Set<T>().ToListAsync();
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
        public async Task Remove(T data)
        {
            ApplicationDbContext.Remove(data);
            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task RemoveId(int id)
        {
            var entity = await ApplicationDbContext.Alarms.Where(o => o.Id == id).FirstAsync();
            ApplicationDbContext.Remove(entity);

            await ApplicationDbContext.SaveChangesAsync();
        }
    }
}
