using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using Domain.Common.Errors;
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
    public class GetUserQuery : IRequest<UserEntity>
    {
        public int Id { get; set; } 
    }
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery,UserEntity>
    {
        private IServiceProvider _serviceProvider;
        public GetUserQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<UserEntity> Handle(GetUserQuery query,CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IUserRepository>();
            var user = await repo.FindAsync(query.Id);

            if (user is null)
            {
                throw new NotFoundException(Errors.User.NotFound);
            }
            return user;
        }
    }
}
