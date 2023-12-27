using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Domain.Common.Pagination
{
    public class PagedResponse<T>
    {
        public IReadOnlyCollection<T> Items { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public int PageNumber { get; }
        public PagedResponse(IReadOnlyCollection<T> items,int count,int pageNumer,int pageSize)
        {
            this.Items = items;
            this.TotalCount = count;
            this.PageNumber = pageNumer;
            this.TotalPages = pageSize;
        }

        public static async Task<PagedResponse<T>> CreateAsync(IQueryable<T> source,int pageNumber,int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedResponse<T>(items, count, pageNumber, pageSize);
        }
    }
}
