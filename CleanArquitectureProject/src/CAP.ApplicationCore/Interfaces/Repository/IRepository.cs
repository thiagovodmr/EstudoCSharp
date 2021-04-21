using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CAP.ApplicationCore.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        IEnumerable<TEntity> SelectAll();
        TEntity SelectById (int id);
        IEnumerable<TEntity> SelectPerson(Expression<Func<TEntity, bool>> predicado);
        TEntity Add(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
       
    }
}
