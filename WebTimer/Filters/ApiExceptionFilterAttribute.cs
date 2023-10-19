using Application.Common.Exceptions;
using Domain.Common;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebTimer.Filters
{
    public class ApiExceptionFilterAttribute:ExceptionFilterAttribute
    {
        private Dictionary<Type, Func<ExceptionContext,Task>> _exceptionHandlers;
        public ApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new()
            {
                {typeof(NotFoundException),HandleNotFoundExceptionAsync }
            };
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var type = context.Exception.GetType();

            if (_exceptionHandlers.ContainsKey(type))
            {
                await _exceptionHandlers[type].Invoke(context);
            }
            base.OnException(context);
        }
        public async Task HandleNotFoundExceptionAsync(ExceptionContext context)
        {
            var _exception = (NotFoundException)context.Exception;

            var result = new ExceptionResult()
            {
                Type = _exception.ErrorType.Type,
                StatusCode = 404,
                Message = _exception.ErrorType.Message,
            };

            await context.HttpContext.Response.WriteAsJsonAsync(result);
            context.ExceptionHandled = true;
        }
    }
}
