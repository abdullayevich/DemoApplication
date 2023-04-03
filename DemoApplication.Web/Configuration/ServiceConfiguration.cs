using DemoApplication.DataAccess.Interfaces;
using DemoApplication.DataAccess.Repositories;
using DemoApplication.Service.Interfaces.Common;
using DemoApplication.Service.Services.Common;

namespace DemoApplication.Web.Configuration
{
    public static class ServiceConfiguration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddHttpContextAccessor();
        }
    }
}
