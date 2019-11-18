using CleanArchExample.Entity.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchExample.Domain.Base
{
    public interface IDomainBaseInterface<T> where T : new()
    {
        Task<ResultEntity<T>> Add(T entity);
        Task<ResultEntity<T>> Update(T entity);
        Task<ResultEntity<T>> Delete(T entity);
        Task<ResultEntity<T>> FindByID(int id);
        Task<ResultList<T>> FindAll();
    }
}
