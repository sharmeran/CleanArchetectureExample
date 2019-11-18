using AutoMapper;
using CleanArchExample.Domain.Interfaces;
using CleanArchExample.Domain.Models;
using CleanArchExample.Entity.Common.Entities;
using CleanArchExample.Entity.Common.Enums;
using CleanArchExample.Entity.Entities;
using CleanArchExample.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchExample.Domain.Domains
{
    public class CompanyDomain : ICompanyDomain
    {
        private ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyDomain(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<ResultEntity<CompanyModel>> Add(CompanyModel entity)
        {
            ResultEntity<CompanyModel> result = new ResultEntity<CompanyModel>();
            try
            {
                result = _mapper.Map<ResultEntity<CompanyModel>>(await _companyRepository.Insert(_mapper.Map<CompanyEntity>(entity)));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<CompanyModel>> Delete(CompanyModel entity)
        {
            ResultEntity<CompanyModel> result = new ResultEntity<CompanyModel>();
            try
            {
                result = _mapper.Map<ResultEntity<CompanyModel>>(await _companyRepository.Delete(_mapper.Map<CompanyEntity>(entity)));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultList<CompanyModel>> FindAll()
        {
            ResultList<CompanyModel> result = new ResultList<CompanyModel>();
            try
            {
                result = _mapper.Map<ResultList<CompanyModel>>(await _companyRepository.FindAll());
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<CompanyModel>> FindByID(int id)
        {
            ResultEntity<CompanyModel> result = new ResultEntity<CompanyModel>();
            try
            {
                result = _mapper.Map<ResultEntity<CompanyModel>>(await _companyRepository.FindByID(id));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<CompanyModel>> Update(CompanyModel entity)
        {
            ResultEntity<CompanyModel> result = new ResultEntity<CompanyModel>();
            try
            {
                result = _mapper.Map<ResultEntity<CompanyModel>>(await _companyRepository.Update(_mapper.Map<CompanyEntity>(entity)));
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
