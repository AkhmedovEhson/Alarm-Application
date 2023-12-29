using Application.Common.Interfaces.IRepositories;
using Domain.Common.Types;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Common.Exceptions;
using Domain.Common.Errors;
using Domain.Entities;

namespace Application.User.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<UserEntity>
    {
        public int Id { get; set; } 
        public string Username { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserEntity>
    {
        private IServiceProvider _serviceProvider;
        public UpdateUserCommandHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
        public async Task<UserEntity> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IUserRepository>();
            var user = await repo.FindAsync(command.Id);

            if (user is null)
            {
                throw new NotFoundException(Errors.User.NotFound);
            }
            user.Username = command.Username;

            await repo.Update(user);

            return user;

        }
    }
}
