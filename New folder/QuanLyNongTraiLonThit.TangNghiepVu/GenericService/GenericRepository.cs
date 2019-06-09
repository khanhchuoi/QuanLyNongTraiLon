using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using QuanLyNongTraiLonThit.TangDuLieu;

namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Fields
        private QuanLyNongTraiLonThitDBContext _context;
        private readonly DbSet<TEntity> _dbSet;
        #endregion

        #region Properties
       
        #endregion

        #region Constructor
        public GenericRepository(QuanLyNongTraiLonThitDBContext dBContext)
        {
            _dbSet = dBContext.Set<TEntity>();
        }
        #endregion

        #region Implements

        public virtual TEntity Find(object id)
        {
            return _dbSet.Find(id);
        }

      

        public virtual TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual int Count()
        {
            return _dbSet.Count();
        }


        public virtual void Update(TEntity entity)
        {
            _dbSet.AddOrUpdate(entity);
        }

        public virtual TEntity Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            return _dbSet.Remove(entity);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

      
        #endregion
    }
}