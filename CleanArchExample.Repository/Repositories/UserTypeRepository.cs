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
  public class UserTypeRepository : IUserTypeRepository
    {
        private ApplicationDBContext dbContext;
        public UserTypeRepository(ApplicationDBContext applicationDBContext)
        {
            dbContext = applicationDBContext;
        }
        public async Task<ResultEntity<UserTypeEntity>> Delete(UserTypeEntity entity)
        {

            ResultEntity<UserTypeEntity> result = new ResultEntity<UserTypeEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.UserTypeDBSet.Remove(entity);
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

        public async Task<ResultList<UserTypeEntity>> FindAll()
        {
            ResultList<UserTypeEntity> result = new ResultList<UserTypeEntity>();
            try
            {
                using (var context = dbContext)
                {
                    var data = await context.UserTypeDBSet.ToListAsync();
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

        public async Task<ResultEntity<UserTypeEntity>> FindByID(int id)
        {
            ResultEntity<UserTypeEntity> result = new ResultEntity<UserTypeEntity>();
            try
            {
                using (var context = dbContext)
                {
                    var data = await context.UserTypeDBSet.FirstOrDefaultAsync(a => a.ID == id);
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

        public async Task<ResultEntity<UserTypeEntity>> Insert(UserTypeEntity entity)
        {
            ResultEntity<UserTypeEntity> result = new ResultEntity<UserTypeEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.UserTypeDBSet.Add(entity);
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

        public async Task<ResultEntity<UserTypeEntity>> Update(UserTypeEntity entity)
        {
            ResultEntity<UserTypeEntity> result = new ResultEntity<UserTypeEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.UserTypeDBSet.Update(entity);
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
