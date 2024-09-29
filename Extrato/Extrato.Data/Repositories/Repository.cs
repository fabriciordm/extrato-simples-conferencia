using Extrato.Data.Context;
using Extrato.Domain.Interface.Commons;
using Extrato.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Extrato.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
    {

        protected TransacaoContext Db;
       // protected DbSet<TEntity> DbSet;
       

        public void Dispose()
        {
            Db.Dispose();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string include = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int page, int size, string include = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int page, int size, out int maxPage, out int totalItens, string order = "asc")
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
