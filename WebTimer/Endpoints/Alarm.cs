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

namespace WebTimer.Endpoints
{
    
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class Alarm : ApiControllerBase
    {
        [HttpGet]
        public async Task<List<AlarmEntity>> GetAsync()
        {
            return await Sender.Send(new GetAlarmsQuery());
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
        public async Task<Unit> PutAsync(UpdateAlarmCommand command)
        {
            return await Sender.Send(command);
        }

        [HttpDelete]
        public async Task<Unit> DeleteAsync(DeleteAlarmCommand command)
        {
            return await Sender.Send(command);
        }
    }
}
