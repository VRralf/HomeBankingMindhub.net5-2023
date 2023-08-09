using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Test3Net6.Models;

namespace Test3Net6.Repositories
{
    public class RepositoryBase<T> : IRepositoriBase<T> where T : class
    {
        protected MyContext RepositoryContext { get; set; }
        public RepositoryBase(MyContext myContext) {
            RepositoryContext = myContext;
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Add(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTrackingWithIdentityResolution();
        }

        public IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null)
        {
            IQueryable<T> queryable = this.RepositoryContext.Set<T>().AsNoTrackingWithIdentityResolution();
            if (includes != null)
            {
                queryable = includes(queryable);
            }
            return queryable.AsNoTrackingWithIdentityResolution();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTrackingWithIdentityResolution();
        }

        public void Save()
        {
            this.RepositoryContext.SaveChanges();
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Update(entity);
        }
    }
}
