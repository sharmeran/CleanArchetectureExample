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
    public class CompanyRepository : ICompanyRepository
    {
        private ApplicationDBContext dbContext;
        public CompanyRepository(ApplicationDBContext applicationDBContext)
        {
            dbContext = applicationDBContext;
        }
        public async Task<ResultEntity<CompanyEntity>> Delete(CompanyEntity entity)
        {

            ResultEntity<CompanyEntity> result = new ResultEntity<CompanyEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.CompanyDBSet.Remove(entity);
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

        public async Task<ResultList<CompanyEntity>> FindAll()
        {
            ResultList<CompanyEntity> result = new ResultList<CompanyEntity>();
            try
            {
                using (var context = dbContext)
                {
                    var data = await context.CompanyDBSet.ToListAsync();
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

        public async Task<ResultEntity<CompanyEntity>> FindByID(int id)
        {
            ResultEntity<CompanyEntity> result = new ResultEntity<CompanyEntity>();
            try
            {
                using (var context = dbContext)
                {
                    var data = await context.CompanyDBSet.FirstOrDefaultAsync(a => a.ID == id);
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

        public async Task<ResultEntity<CompanyEntity>> Insert(CompanyEntity entity)
        {
            ResultEntity<CompanyEntity> result = new ResultEntity<CompanyEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.CompanyDBSet.Add(entity);
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

        public async Task<ResultEntity<CompanyEntity>> Update(CompanyEntity entity)
        {
            ResultEntity<CompanyEntity> result = new ResultEntity<CompanyEntity>();
            try
            {
                using (var context = dbContext)
                {
                    context.CompanyDBSet.Update(entity);
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
