using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using Domain.Common.Errors;
using Domain.Common.Types;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.Commands.DeleteUserCommand
{
    public class DeleteUserCommand : IRequest<Deleted>
    {
        public int Id { get; set; } 
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Deleted>
    {
        private IServiceProvider _serviceProvider;
        public DeleteUserCommandHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
        public async Task<Deleted> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IUserRepository>();
            bool IsNotFound = await repo.RemoveId(command.Id) > 0;    

            if (IsNotFound)
            {
                throw new NotFoundException(Errors.User.NotFound);
            }
            return new Deleted(command.Id);
        }
    }
}
