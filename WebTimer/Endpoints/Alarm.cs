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

namespace WebTimer.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class Alarm : ApiControllerBase
    {
        [HttpGet]
        public async Task GetAsync()
        {
            await Sender.Send(new GetAlarmsQuery());
        }

        [Route("{id}")]
        [HttpGet]
        public async Task GetByIdAsync([FromRoute] GetAlarmByIdQuery query)
        {
            await Sender.Send(new GetAlarmByIdQuery());
        }
        [HttpPost]
        public async Task PostAsync()
        {
            await Sender.Send(new CreateAlarmCommand());
        }

        [HttpPut]
        public async Task PutAsync()
        {
            await Sender.Send(new UpdateAlarmCommand());
        }

        [HttpDelete]
        public async Task DeleteAsync()
        {
            await Sender.Send(new DeleteAlarmCommand());
        }
    }
}
