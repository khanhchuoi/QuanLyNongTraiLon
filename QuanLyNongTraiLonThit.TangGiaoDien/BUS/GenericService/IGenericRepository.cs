using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuanLyNongTraiLonThit.TangNghiepVu
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        TEntity Delete(TEntity entity);
        int Count();
        TEntity Find(object id);

        IQueryable<TEntity> GetAll();
       
    }
}
