using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using Domain.Common.Errors;
using Domain.Common.Types;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alarm.Commands.UpdateAlarmCommand
{
    public class UpdateAlarmCommand:IRequest<Success>
    {
        public int Id { get; set; } = 0;
        public DateTime RingAt { get; set; }
    }

    public class UpdateAlarmCommandHandler : IRequestHandler<UpdateAlarmCommand, Success>
    {
        private readonly IServiceProvider _serviceProvider;
        public UpdateAlarmCommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Success> Handle(UpdateAlarmCommand command,CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IAlarmRepository>();
            var entity = await repo.FindAsync(command.Id) ?? throw new NotFoundException(Errors.Alarm.NotFound);

            entity.RingAt = command.RingAt;

            await repo.Update(entity);

            return new Success(entity.Id);
        }
    }
}
