using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alarm.Commands.UpdateAlarmCommand
{
    public class UpdateAlarmCommand:IRequest<Unit>
    {
        public int Id { get; set; } = 0;
        public DateTime RingAt { get; set; }
    }

    public class UpdateAlarmCommandHandler : IRequestHandler<UpdateAlarmCommand, Unit>
    {
        private readonly IServiceProvider _serviceProvider;
        public UpdateAlarmCommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Unit> Handle(UpdateAlarmCommand command,CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IAlarmRepository>();
            var entity = await repo.FindAsync(command.Id) ?? throw new NotFoundException();

            entity.RingAt = command.RingAt;

            await repo.Update(entity);
            
            return Unit.Value;       
        }
    }
}
