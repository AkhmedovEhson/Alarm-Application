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
using Application.Common.Exceptions;
namespace WebTimer.Endpoints
{
    
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class Alarm : ApiControllerBase
    {
        /// <summary>
        /// `GetAsync` - gets all alarms with pagination <seealso cref="PagedResponse{T}"/>
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResponse<AlarmEntity>> GetAsync([FromQuery] GetAlarmsQuery query)
        {
            return await Sender.Send(query);
        }
        /// <summary>
        /// `GetByIdAsync` - finds alarm <seealso cref="AlarmEntity"/>, throws <seealso cref="NotFoundException"/> if alarm can not be found
        /// </summary>
        /// <param name="query"></param>
        /// <exception cref="NotFoundException"/>
        /// <returns></returns>
        [Route("{Id}")]
        [HttpGet]
        public async Task<AlarmEntity> GetByIdAsync([FromRoute] GetAlarmByIdQuery query)
        {
            return await Sender.Send(query);
        }
        /// <summary>
        /// `PostAsync` - creates alarm
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AlarmEntity> PostAsync(CreateAlarmCommand command)
        {
            return await Sender.Send(command);
        }
        /// <summary>
        /// `PutAsync` - updates alarm
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Success> PutAsync(UpdateAlarmCommand command)
        {
            return await Sender.Send(command);
        }
        /// <summary>
        /// `DeleteAsync` - deletes alarm
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<Deleted> DeleteAsync(DeleteAlarmCommand command)
        {
            return await Sender.Send(command);
        }
    }
}
