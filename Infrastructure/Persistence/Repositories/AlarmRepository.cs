using Application.Common.Interfaces.IRepositories;
using Domain.Entities;
using Domain.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class AlarmRepository:Repository<AlarmEntity>, IAlarmRepository
    {
        private readonly ApplicationDbContext _context;

        public AlarmRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public Task<List<AlarmType>> GetValuesAsync(bool byDescending = true)
        {
            return GetValuesQueryable()
                  .OrderByDescending(o => o.Id)
                  .Select<AlarmEntity, AlarmType>(o => new AlarmType()
            {
                Day = o.RingAt.Day.ToString(),
                Hour = o.RingAt.Hour.ToString(),
                Minute = o.RingAt.Minute.ToString(),
                Second = o.RingAt.Second.ToString(),
            }).ToListAsync();
        }
    }
}
