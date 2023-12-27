using Application.Common.Interfaces.IRepositories;
using Domain.Common.Pagination;
using Domain.Entities;
using Domain.Types;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alarm.Queries.GetAlarms
{
    public class GetAlarmsQuery:IRequest<PagedResponse<AlarmEntity>>
    {
        public int PageNumber { get;set; }
        public int PageSize { get; set; }
    }

    public class GetAlarmsQueryHandler : IRequestHandler<GetAlarmsQuery, PagedResponse<AlarmEntity>>
    {
        private readonly IServiceProvider _serviceProvider;
        public GetAlarmsQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Task<PagedResponse<AlarmEntity>> Handle(GetAlarmsQuery query,CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IAlarmRepository>();

            return repo.GetPagedResponse(query.PageNumber, query.PageSize);

        }
    }
}
