using Microsoft.EntityFrameworkCore;
using ProjektFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjektFinal.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FilmContext FilmContext { get; set; }
        public RepositoryBase(FilmContext filmContext)
        {
            this.FilmContext = filmContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.FilmContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.FilmContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.FilmContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.FilmContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.FilmContext.Set<T>().Remove(entity);
        }
    }
}
