using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AplicationNet6.Repositories
{
    public interface IRepositoriBase<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
