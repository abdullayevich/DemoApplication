using DemoApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.DataAccess.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
