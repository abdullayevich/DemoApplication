using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        public IAdminRepository Admins { get; }
        public IUserRepository Users { get; }
        public IProductRepository Products { get; }
        public IProductAuditRepository ProductAudits { get; }
        public Task<int> SaveChangesAsync();
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
