using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class AlarmEntityConfiguration:IEntityTypeConfiguration<AlarmEntity>
    {
        public void Configure(EntityTypeBuilder<AlarmEntity> builder)
        {
            builder.Property("RingAt").IsRequired();
        }
    }
}
