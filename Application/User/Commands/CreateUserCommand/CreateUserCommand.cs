using Application.Common.Interfaces.IRepositories;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using BCrypt.Net;
using Domain.Common;
using System.Text;

namespace Application.User.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<UserEntity>
    {
        public string UserName { get; set; }    
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand,UserEntity>
    {
        private IServiceProvider _serviceProvider;
        public CreateUserCommandHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
        public async Task<UserEntity> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IUserRepository>();

            var user = new UserEntity()
            {
                Username = command.UserName,
                Password = Convert.FromBase64String(BCrypt.Net.BCrypt.HashPassword(command.Password))
            };

            await repo.AddAsync(user);
            return user;
        }
    }
}
