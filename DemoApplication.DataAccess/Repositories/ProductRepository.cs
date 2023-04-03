using DemoApplication.DataAccess.DbContexts;
using DemoApplication.DataAccess.Interfaces;
using DemoApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
