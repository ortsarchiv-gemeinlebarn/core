using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using oag.Core.Data.Contexts;
using oag.Core.Data.Interfaces;

namespace oag.Core.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private DataContext dataContext;

        protected Repository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public T Create(T entity)
        {
            dataContext.Add(entity);
            return entity;
        }

        public IQueryable<T> ReadAll()
        {
            return dataContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> ReadByCondition(Expression<Func<T, bool>> expression)
        {
            return dataContext.Set<T>().Where(expression).AsNoTracking();
        }

        public T Update(T entity)
        {
            dataContext.Update(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            dataContext.Remove(entity);
            return entity;
        }

        public async Task<int> SaveAsync()
        {
            return await dataContext.SaveChangesAsync();
        }
    }
}
