using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Challenge.Dal.Interfaces;

namespace Challenge.Dal
{
    /// <summary>
    ///     Generic Respository Class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        ///     Return the count of elements stored
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return Context.Set<TEntity>().Count();
        }

        /// <summary>
        ///     Add an entity
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        ///     Fetch an Entity with associeted id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        ///     Get all Entity sotored
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        ///     Remove the associed Entity
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        ///     Update the associeted Entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        ///     Order Entity by predicate with pagination. The predicate must be int type
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, int>> predicate, int page, int pageSize)
        {
            return Context.Set<TEntity>().OrderBy(predicate).Skip(page).Take(pageSize).ToList();
        }

        /// <summary>
        ///     Order Entity Descending by predicate with pagination. The predicate must be an int type
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, int>> predicate, int page, int pageSize)
        {
            return Context.Set<TEntity>().OrderByDescending(predicate).Skip(page).Take(pageSize).ToList();
        }

        /// <summary>
        ///     Order Entity by predicate with pagination. The predicate must be a string type
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, string>> predicate, int page, int pageSize)
        {
            return Context.Set<TEntity>().OrderBy(predicate).Skip(page).Take(pageSize).ToList();
        }

        /// <summary>
        ///     Order Entity Descending by predicate with pagination. The predicate must be a string type
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, string>> predicate, int page,
            int pageSize)
        {
            return Context.Set<TEntity>().OrderByDescending(predicate).Skip(page).Take(pageSize).ToList();
        }

        /// <summary>
        ///     Order Entity by predicate with pagination. The predicate must be a DateTime? type
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, DateTime?>> predicate, int page, int pageSize)
        {
            return Context.Set<TEntity>().OrderBy(predicate).Skip(page).Take(pageSize).ToList();
        }

        /// <summary>
        ///     Order Entity Descending by predicate with pagination. The predicate must be a DateTime? type
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> OrderByDescending(Expression<Func<TEntity, DateTime?>> predicate, int page,
            int pageSize)
        {
            return Context.Set<TEntity>().OrderByDescending(predicate).Skip(page).Take(pageSize).ToList();
        }
    }
}