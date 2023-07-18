﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HomeBankingMindhub.Repositories
{
    //TODO: Implementar la interfaz IRepositoryBase<T> con los métodos necesarios para que funcione el proyecto.
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindAll(Func<IQueryable<T>,IIncludableQueryable<T,object>>includes=null);
        IQueryable<T> FindByCondition(Expression<Func<T,bool>>expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
