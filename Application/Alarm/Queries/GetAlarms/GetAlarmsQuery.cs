using Application.Common.Interfaces.IRepositories;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alarm.Queries.GetAlarms
{
    public class GetAlarmsQuery:IRequest<List<AlarmEntity>>
    {}

    public class GetAlarmsQueryHandler : IRequestHandler<GetAlarmsQuery, List<AlarmEntity>>
    {
        private readonly IServiceProvider _serviceProvider;
        public GetAlarmsQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Task<List<AlarmEntity>> Handle(GetAlarmsQuery query,CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IAlarmRepository>();

            return repo.GetValuesAsync();
        }
    }
}
