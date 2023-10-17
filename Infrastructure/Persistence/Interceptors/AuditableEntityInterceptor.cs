using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Interceptors
{
    public class AuditableEntityInterceptor:SaveChangesInterceptor
    {
        public AuditableEntityInterceptor()
        { }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData,InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result,cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
            if (context != null) return;

            foreach(var entity in context!.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.Created = DateTime.UtcNow;
                    entity.Entity.Updated = DateTime.UtcNow;
                }
                else if (entity.State == EntityState.Modified)
                {
                    entity.Entity.Updated = DateTime.UtcNow;
                }

            }

        }
    }
}
