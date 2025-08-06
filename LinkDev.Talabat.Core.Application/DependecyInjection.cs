using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.Mapping;
using LinkDev.Talabat.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace LinkDev.Talabat.Core.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddScoped(typeof(IServiceManager),typeof(ServiceManager));
            return services;
        }
    }
}
