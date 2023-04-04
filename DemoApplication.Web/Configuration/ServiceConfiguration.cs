using DemoApplication.DataAccess.Interfaces;
using DemoApplication.DataAccess.Repositories;
using DemoApplication.Service.Interfaces.Accounts;
using DemoApplication.Service.Interfaces.Common;
using DemoApplication.Service.Interfaces.Products;
using DemoApplication.Service.Services.Accounts;
using DemoApplication.Service.Services.Common;
using DemoApplication.Service.Services.Products;

namespace DemoApplication.Web.Configuration
{
    public static class ServiceConfiguration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddHttpContextAccessor();
        }
    }
}
