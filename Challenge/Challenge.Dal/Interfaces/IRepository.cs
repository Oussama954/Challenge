using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Challenge.Dal.Interfaces
{
    /// <summary>
    /// Generic Repository Interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        int Count();
        IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, int>> predicate, int page, int pageSize);
        IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, int>> predicate, int page, int pageSize);
        IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, string>> predicate, int page, int pageSize);
        IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, string>> predicate, int page, int pageSize);
        IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, DateTime?>> predicate, int page, int pageSize);
        IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, DateTime?>> predicate, int page, int pageSize);
    }
}
