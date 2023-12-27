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

namespace Application.Alarm.Commands.DeleteAlarmCommand
{
    public class DeleteAlarmCommand : IRequest<Deleted>
    {
        public int Id { get; set; } = 0;
    }

    public class DeleteAlarmCommandHandler : IRequestHandler<DeleteAlarmCommand, Deleted>
    {
        private readonly IServiceProvider _serviceProvider;
        public DeleteAlarmCommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Deleted> Handle(DeleteAlarmCommand command, CancellationToken cancellationToken)
        {
            var repo = _serviceProvider.GetRequiredService<IAlarmRepository>();
           
            if (await repo.RemoveId(command.Id) > 0) 
                throw new NotFoundException(Errors.Alarm.NotFound);

            return new Deleted(command.Id);
        }
    }
}
