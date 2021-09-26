using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace oag.Core.Data.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T entity);
        IQueryable<T> ReadAll();
        IQueryable<T> ReadByCondition(Expression<Func<T, bool>> expression);
        T Update(T entity);
        T Delete(T entity);
        Task<int> SaveAsync();
    }
}
