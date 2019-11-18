using CleanArchExample.Entity.Common.Entities;
using CleanArchExample.Entity.Common.Enums;
using CleanArchExample.Entity.Entities;
using CleanArchExample.Repository.Common;
using CleanArchExample.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchExample.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDBContext dbContext;
        public EmployeeRepository(ApplicationDBContext applicationDBContext)
        {
            dbContext = applicationDBContext;
        }
        public async Task<ResultEntity<EmployeeEntity>> Delete(EmployeeEntity entity)
        {

            ResultEntity<EmployeeEntity> result = new ResultEntity<EmployeeEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.EmployeeDBSet.Remove(entity);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultList<EmployeeEntity>> FindAll()
        {
            ResultList<EmployeeEntity> result = new ResultList<EmployeeEntity>();
            try
            {
                using (var context = dbContext)
                {
                    var data = await context.EmployeeDBSet.ToListAsync();
                    if (data.Count > 0)
                        result.List = data;
                    else
                    {
                        result.Status = StatusTypeEnum.Warning;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<EmployeeEntity>> FindByID(int id)
        {
            ResultEntity<EmployeeEntity> result = new ResultEntity<EmployeeEntity>();
            try
            {
                using (var context = dbContext)
                {
                    var data = await context.EmployeeDBSet.FirstOrDefaultAsync(a => a.ID == id);
                    if (data != null)
                        result.Entity = data;
                    else
                    {
                        result.Status = StatusTypeEnum.Warning;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<EmployeeEntity>> Insert(EmployeeEntity entity)
        {
            ResultEntity<EmployeeEntity> result = new ResultEntity<EmployeeEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.EmployeeDBSet.Add(entity);
                    await context.SaveChangesAsync();
                    result.Entity = entity;
                }
            }
            catch (Exception ex)
            {
                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<EmployeeEntity>> Update(EmployeeEntity entity)
        {
            ResultEntity<EmployeeEntity> result = new ResultEntity<EmployeeEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.EmployeeDBSet.Update(entity);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }
    }
}
