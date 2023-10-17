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
        public ApplicationDbContext ApplicationDbContext;

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
    }
}
