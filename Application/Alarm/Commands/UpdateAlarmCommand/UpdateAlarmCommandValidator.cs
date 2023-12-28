using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alarm.Commands.UpdateAlarmCommand
{
    public class UpdateAlarmCommandValidator : AbstractValidator<UpdateAlarmCommand>
    {
        public UpdateAlarmCommandValidator()
        {
            RuleFor(o => o.RingAt).Must(Validations.RestrictRingAt);
        }
    }
}
