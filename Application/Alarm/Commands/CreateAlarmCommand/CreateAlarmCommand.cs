using Application.Common.Interfaces.IRepositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Domain.Entities;

namespace Application.Alarm.Commands.CreateAlarmCommand
{
    public class CreateAlarmCommand:IRequest<AlarmEntity>
    {
        public DateTime RingAt { get; set; }
    }

    public class CreateAlarmCommandHandler : IRequestHandler<CreateAlarmCommand, AlarmEntity>
    {
        private readonly IServiceProvider _serviceProvider;

        public CreateAlarmCommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<AlarmEntity> Handle(CreateAlarmCommand command,CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IAlarmRepository>();

            var entity = new AlarmEntity()
            {
                RingAt = command.RingAt
            };

            await repo.AddAsync(entity);

            return entity;
        }
    }
}
