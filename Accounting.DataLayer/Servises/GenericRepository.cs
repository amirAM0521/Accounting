﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.DataLayer.Servises
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private AccountingDBEntities1 _db;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(AccountingDBEntities1 db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            //_dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            //if (_db.Entry(entity).State == EntityState.Modified)
            //{
            //    _dbSet.Attach(entity);
            //}
            //_dbSet.Remove(entity);
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public virtual void Delete(object ID)
        {
            //var entity = GetById(ID);
            //Delete(entity);
            var entity = GetById(ID);
            Delete(entity);
        }

        public virtual TEntity GetById(object ID)
        {
            return _dbSet.Find(ID);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (where != null)
            {
                query = query.Where(where);
            }
            return query.ToList();
        }
    }
}
