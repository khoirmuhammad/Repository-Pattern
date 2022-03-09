using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext _applicationContext { get; set; }
        public RepositoryBase(ApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }

        public void Create(T entity)
        {
            this._applicationContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this._applicationContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this._applicationContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._applicationContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this._applicationContext.Set<T>().Update(entity);
        }

        public void SoftDelete(T entity)
        {
            this._applicationContext.Set<T>().Update(entity);
        }
    }
}
