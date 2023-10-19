using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using Domain.Common.Errors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alarm.Commands.DeleteAlarmCommand
{
    public class DeleteAlarmCommand : IRequest<Unit>
    {
        public int Id { get; set; } = 0;
    }

    public class DeleteAlarmCommandHandler : IRequestHandler<DeleteAlarmCommand, Unit>
    {
        private readonly IServiceProvider _serviceProvider;
        public DeleteAlarmCommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Unit> Handle(DeleteAlarmCommand command, CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IAlarmRepository>();
           
            if (await repo.RemoveId(command.Id) > 0) 
                throw new NotFoundException(Errors.Alarm.NotFound);

            return Unit.Value;
        }
    }
}
