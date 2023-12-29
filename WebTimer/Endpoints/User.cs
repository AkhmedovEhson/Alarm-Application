using Application.User.Commands.CreateUserCommand;
using Application.User.Commands.DeleteUserCommand;
using Application.User.Commands.UpdateUserCommand;
using Application.User.Queries;
using Domain.Common.Pagination;
using Domain.Common.Types;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTimer.Common;
using Application.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace WebTimer.Endpoints
{
    /// <summary>
    /// Common set of `User`'s Commands&Queries
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class User : ApiControllerBase
    {
        /// <summary>
        /// `CreateUserCommand` - creates new user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<UserEntity> Post(CreateUserCommand command) => await Sender.Send(command);
        /// <summary>
        /// `UpdateUserCommand` - updates user's info, if user does not exist, throws <seealso cref="NotFoundException"/>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<UserEntity> Update(UpdateUserCommand command) => await Sender.Send(command);
        /// <summary>
        /// `DeleteUserCommand` - deletes user, if user does not exist, throws <seealso cref="NotFoundException"/>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        
        [HttpDelete("{Id}")]
        public async Task<Deleted> Delete([FromRoute]DeleteUserCommand command) => await Sender.Send(command);
        /// <summary>
        /// `GetUsersQueryWithPaginationQuery` - looks for all users, responds with pagination
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("All")]
        public async Task<PagedResponse<UserEntity>> All([FromQuery] GetUsersQueryWithPaginationQuery query) => await Sender.Send(query);
        /// <summary>
        /// `GetUserQuery` - finds user by `ID`, if user does not exist, throws <seealso cref="NotFoundException"/>
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("{Id}")]
        public async Task<UserEntity> Get([FromRoute]GetUserQuery query) => await Sender.Send(query);
        /// <summary>
        /// `SignInQuery` - generates token with provided user's credentials
        /// <br/>`NotFoundException` - throws if `username` could not be found in database
        /// <br/>`PasswordException` - throws if `password` is wrong
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"/>
        /// <exception cref="PasswordException"/>
        [HttpPost("Login")]
        public async Task<string> Login(SignInQuery query) => await Sender.Send(query);

    }
}
