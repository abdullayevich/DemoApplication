using System;
using DemoApplication.DataAccess.DbContexts;
using DemoApplication.DataAccess.Interfaces;
using DemoApplication.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Web.Configuration
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            string connectionString = configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
