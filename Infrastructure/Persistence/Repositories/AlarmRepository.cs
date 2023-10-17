using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class AlarmRepository:Repository<AlarmEntity>
    {
        private readonly ApplicationDbContext _context;

        public AlarmRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
