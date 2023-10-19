using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using Domain.Common.Errors;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Alarm.Queries.GetAlarmById
{
    public class GetAlarmByIdQuery:IRequest<AlarmEntity>
    {
        public int Id { get; set; }
    }

    public class GetAlarmByIdQueryHandler:IRequestHandler<GetAlarmByIdQuery,AlarmEntity>
    {
        private readonly IServiceProvider _serviceProvider;
        public GetAlarmByIdQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<AlarmEntity> Handle(GetAlarmByIdQuery entity,CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IAlarmRepository>();

            var alarm = await repo.FindAsync(entity.Id) ?? throw new NotFoundException(Errors.Alarm.NotFound);

            return alarm;
        }
    }
}
