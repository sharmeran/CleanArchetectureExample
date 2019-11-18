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
    public class UserTypeDomain : IUserTypeDomain
    {
        private IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;

        public UserTypeDomain(IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            _userTypeRepository = userTypeRepository;
            _mapper = mapper;
        }
        public async Task<ResultEntity<UserTypeModel>> Add(UserTypeModel entity)
        {
            ResultEntity<UserTypeModel> result = new ResultEntity<UserTypeModel>();
            try
            {
                result = _mapper.Map<ResultEntity<UserTypeModel>>(await _userTypeRepository.Insert(_mapper.Map<UserTypeEntity>(entity)));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<UserTypeModel>> Delete(UserTypeModel entity)
        {
            ResultEntity<UserTypeModel> result = new ResultEntity<UserTypeModel>();
            try
            {
                result = _mapper.Map<ResultEntity<UserTypeModel>>(await _userTypeRepository.Delete(_mapper.Map<UserTypeEntity>(entity)));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultList<UserTypeModel>> FindAll()
        {
            ResultList<UserTypeModel> result = new ResultList<UserTypeModel>();
            try
            {
                result = _mapper.Map<ResultList<UserTypeModel>>(await _userTypeRepository.FindAll());
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<UserTypeModel>> FindByID(int id)
        {
            ResultEntity<UserTypeModel> result = new ResultEntity<UserTypeModel>();
            try
            {
                result = _mapper.Map<ResultEntity<UserTypeModel>>(await _userTypeRepository.FindByID(id));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<UserTypeModel>> Update(UserTypeModel entity)
        {
            ResultEntity<UserTypeModel> result = new ResultEntity<UserTypeModel>();
            try
            {
                result = _mapper.Map<ResultEntity<UserTypeModel>>(await _userTypeRepository.Update(_mapper.Map<UserTypeEntity>(entity)));
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
