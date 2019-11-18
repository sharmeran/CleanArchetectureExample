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
   public class UserRepository: IUserRepository
    {
        private ApplicationDBContext dbContext;
        public UserRepository(ApplicationDBContext applicationDBContext)
        {
            dbContext = applicationDBContext;
        }
        public async Task<ResultEntity<UserEntity>> Delete(UserEntity entity)
        {

            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.UserDBSet.Remove(entity);
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

        public async Task<ResultList<UserEntity>> FindAll()
        {
            ResultList<UserEntity> result = new ResultList<UserEntity>();
            try
            {
                using (var context = dbContext)
                {
                    var data = await context.UserDBSet.ToListAsync();
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

        public async Task<ResultEntity<UserEntity>> FindByID(int id)
        {
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();
            try
            {
                using (var context = dbContext)
                {
                    var data = await context.UserDBSet.FirstOrDefaultAsync(a => a.ID == id);
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

        public async Task<ResultEntity<UserEntity>> Insert(UserEntity entity)
        {
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.UserDBSet.Add(entity);
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

        public async Task<ResultEntity<UserEntity>> Update(UserEntity entity)
        {
            ResultEntity<UserEntity> result = new ResultEntity<UserEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.UserDBSet.Update(entity);
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
