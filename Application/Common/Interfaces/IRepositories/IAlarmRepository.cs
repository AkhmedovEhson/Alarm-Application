using Domain.Entities;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.IRepositories
{
    public interface IAlarmRepository : IRepository<AlarmEntity>
    {
        Task<List<AlarmType>> GetValuesAsync(bool byDescending);
    }
}
