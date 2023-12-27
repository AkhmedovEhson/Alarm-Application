using Domain.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure
{
    public static class Pagination
    {
        public static Task<PagedResponse<T>> PagedListResponse<T>(this IQueryable<T> query, int pageNumber, int pageSize) 
            => PagedResponse<T>.CreateAsync(query, pageNumber, pageSize);
    }
}
