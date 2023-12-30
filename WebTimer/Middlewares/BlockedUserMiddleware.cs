using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebTimer.Middlewares
{
    public class BlockedUserMiddleware
    {
        private RequestDelegate _next;
        private IMemoryCache _cache;
        private ICurrentUserService _currentUserService;

        public BlockedUserMiddleware(
            RequestDelegate next,
            IMemoryCache cache,
            ICurrentUserService currentUserService)
        {
            _next = next;
            _cache = cache;
            _currentUserService = currentUserService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            bool isBlocked = _cache.Get($"userId:{_currentUserService.GetId()}") != null;
            if (isBlocked)
            {
                throw new ForbidException();
            }
            await _next(context);
        }
    }
}
