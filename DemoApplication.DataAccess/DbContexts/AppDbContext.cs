using Microsoft.EntityFrameworkCore;
using DemoApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.DataAccess.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext)
            : base(dbContext)
        {
            
        }

        public virtual DbSet<User> Users { get; set; } = default!;
        public virtual DbSet<Admin> Admins { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;
        public virtual DbSet<ProductAudit> ProductAudits { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
