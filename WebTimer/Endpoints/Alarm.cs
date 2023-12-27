using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTimer.Common;
using Application.Alarm.Commands;
using Application.Alarm.Queries;
using Application.Alarm.Queries.GetAlarms;
using Application.Alarm.Commands.CreateAlarmCommand;
using Application.Alarm.Commands.UpdateAlarmCommand;
using Application.Alarm.Commands.DeleteAlarmCommand;
using Application.Alarm.Queries.GetAlarmById;
using Domain.Entities;
using MediatR;
using WebTimer.Filters;
using Microsoft.AspNetCore.Cors;
using Domain.Types;
using Domain.Common.Types;
using Domain.Common.Pagination;

namespace WebTimer.Endpoints
{
    
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class Alarm : ApiControllerBase
    {
        [HttpGet]
        public async Task<PagedResponse<AlarmEntity>> GetAsync([FromQuery] GetAlarmsQuery query)
        {
            return await Sender.Send(query);
        }

        [Route("{Id}")]
        [HttpGet]
        public async Task<AlarmEntity> GetByIdAsync([FromRoute] GetAlarmByIdQuery query)
        {
            return await Sender.Send(query);
        }

        [HttpPost]
        public async Task<AlarmEntity> PostAsync(CreateAlarmCommand command)
        {
            return await Sender.Send(command);
        }

        [HttpPut]
        public async Task<Success> PutAsync(UpdateAlarmCommand command)
        {
            return await Sender.Send(command);
        }

        [HttpDelete]
        public async Task<Deleted> DeleteAsync(DeleteAlarmCommand command)
        {
            return await Sender.Send(command);
        }
    }
}
