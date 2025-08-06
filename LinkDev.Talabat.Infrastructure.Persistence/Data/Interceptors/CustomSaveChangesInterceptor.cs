using LinkDev.Talabat.Core.Application.Abstraction;
using LinkDev.Talabat.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Persistence.Data.Interceptors
{
    public class CustomSaveChangesInterceptor:SaveChangesInterceptor
    {
        private readonly ILoggedInUserService loggedInUser;

        public CustomSaveChangesInterceptor(ILoggedInUserService loggedInUser)
        {
            this.loggedInUser = loggedInUser;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }
        private void UpdateEntities(DbContext? dbContext) {

            if (dbContext is null)
                return;
            foreach(var entry in dbContext.ChangeTracker.Entries<BaseAuditableEntity<int>>().Where(entity=>entity.State is EntityState.Modified or EntityState.Added))     { 
            
            
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = loggedInUser.UserId!;
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                }


                entry.Entity.LastModifiedBy= loggedInUser.UserId!;
                entry.Entity.LastModifiedOn=DateTime.UtcNow;

            }
        
        
        
        
        }




    }
}
