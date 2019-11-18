using CleanArchExample.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchExample.Repository.Base
{
    public interface BaseRepositoryInterface<T> where T : new()
    {
        Task<ResultEntity<T>> Insert(T entity);
        Task<ResultEntity<T>> Update(T entity);
        Task<ResultEntity<T>> Delete(T entity);
        Task<ResultEntity<T>> FindByID(int id);
        Task<ResultList<T>> FindAll();
    }
}
