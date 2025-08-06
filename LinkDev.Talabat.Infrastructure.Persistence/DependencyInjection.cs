﻿using LinkDev.Talabat.Core.Domain.Contract.Persistence;
using LinkDev.Talabat.Infrastructure.Persistence.Data;
using LinkDev.Talabat.Infrastructure.Persistence.Data.Interceptors;
using LinkDev.Talabat.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {


            services.AddDbContext<StoreDbContext>((optionsBuilder) =>
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("StoreContext"));
              });
            services.AddScoped(typeof(IStoreContextIntializer), typeof(StoreContextIntializer));
            services.AddScoped(typeof(ISaveChangesInterceptor), typeof(CustomSaveChangesInterceptor));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork.UnitOfWork));


            return services;
        }
    }
}
