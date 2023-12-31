
using Application.Common.Interfaces.IRepositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Application.Common.Exceptions;
using System.Security.Claims;
namespace Domain.Infrastructure.Identity
{
    public class CurrentUserService:ICurrentUserService
    {
        private IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public int GetId()
        {
            return int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtRegisteredClaimNames.Jti) ?? "0");
        }

    }
}
