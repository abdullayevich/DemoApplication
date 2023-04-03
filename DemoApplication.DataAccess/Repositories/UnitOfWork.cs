using DemoApplication.DataAccess.DbContexts;
using DemoApplication.DataAccess.Interfaces;
using DemoApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            Admins = new AdminRepository(dbContext);
            Users = new UserRepository(dbContext);
            Products = new ProductRepository(dbContext);
            ProductAudits = new ProductAuditRepository(dbContext);
        }
        public IAdminRepository Admins { get; }

        public IUserRepository Users { get; }

        public IProductRepository Products { get; }

        public IProductAuditRepository ProductAudits { get; }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return dbContext.Entry(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
