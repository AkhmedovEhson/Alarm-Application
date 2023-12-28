using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Alarm.Commands.CreateAlarmCommand
{
    /// <summary>
    /// CreateAlarmCommandValidator - validates props, catches errors if some statements do not match
    /// </summary>
    public class CreateAlarmCommandValidator:AbstractValidator<CreateAlarmCommand>
    {
        public CreateAlarmCommandValidator()
        {
            RuleFor(o => o.RingAt).Must(Validations.RestrictRingAt);
        }
        

    }
}
