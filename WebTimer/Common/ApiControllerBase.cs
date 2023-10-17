using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebTimer.Common
{
    public class ApiControllerBase:ControllerBase
    {
        protected ISender Sender => HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
