using DemoApplication.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<T?> FindByIdAsync(int id);

        public Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression);

        public T Add(T entity);

        public void Update(int id, T entity);

        public void Delete(int id);
        public IQueryable<T> GetAll();
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        public void TrackingDeteched(T entity);
    }
}
