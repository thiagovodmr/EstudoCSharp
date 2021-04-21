using CAP.ApplicationCore.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CAP.Infraestructure.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly DbContext _dbContext;

        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual TEntity Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual void Atualizar(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Remover(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> SelectAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().AsEnumerable();
        }

        public TEntity SelectById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> SelectPerson(Expression<Func<TEntity, bool>> predicado)
        {
            return _dbContext.Set<TEntity>().Where(predicado).AsNoTracking().AsEnumerable();
        }
    }
}
