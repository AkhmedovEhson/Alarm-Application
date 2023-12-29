using Application.Common.Interfaces.IRepositories;
using Domain.Common.Pagination;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Queries
{
    public class GetUsersQueryWithPaginationQuery : IRequest<PagedResponse<UserEntity>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get;set; }
    }

    public class GetUsersQueryWithPaginationQueryHandler : IRequestHandler<GetUsersQueryWithPaginationQuery, PagedResponse<UserEntity>>
    {
        private readonly IServiceProvider _serviceProvider;
        public GetUsersQueryWithPaginationQueryHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<PagedResponse<UserEntity>> Handle(GetUsersQueryWithPaginationQuery query,CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IUserRepository>();
            var users = await repo.GetPagedResponse(query.PageIndex,query.PageSize);
            return users;
        }
    }

}
