using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.IRepositories
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetValuesAsync();
        public ValueTask<T?> FindAsync(int id);
        public Task AddAsync(T data);
        public Task Update(T data);
        public Task Remove(T data);
        public Task<int> RemoveId(int id);
    }
}
