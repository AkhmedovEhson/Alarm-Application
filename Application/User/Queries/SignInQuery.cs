using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using BCrypt.Net;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Infrastructure.Identity;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bcrypt = BCrypt.Net;

namespace Application.User.Queries
{
    public class SignInQuery:IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set;}
    }

    public class SignInQueryHandler : IRequestHandler<SignInQuery, string>
    {
        private readonly IServiceProvider _serviceProvider;
        public SignInQueryHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<string> Handle(SignInQuery query,CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IUserRepository>();
            var queriedUser = await repo.FindAsync(query.Username) ?? throw new NotFoundException(Errors.User.UsernameNotFound);


            string expectedPassword = bcrypt::BCrypt.HashPassword(query.Password);

            if (!bcrypt::BCrypt.Verify(query.Password,expectedPassword))
            {
                throw new PasswordException(Errors.User.WrongPassword);
            }

            return TokenGenerator.GenerateToken(queriedUser);

        }
    }
}
