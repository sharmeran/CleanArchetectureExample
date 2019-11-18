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
   public class UserDomain : IUserDomain
    {

        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserDomain(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ResultEntity<UserModel>> Add(UserModel entity)
        {
            ResultEntity<UserModel> result = new ResultEntity<UserModel>();
            try
            {
                result = _mapper.Map<ResultEntity<UserModel>>(await _userRepository.Insert(_mapper.Map<UserEntity>(entity)));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<UserModel>> Delete(UserModel entity)
        {
            ResultEntity<UserModel> result = new ResultEntity<UserModel>();
            try
            {
                result = _mapper.Map<ResultEntity<UserModel>>(await _userRepository.Delete(_mapper.Map<UserEntity>(entity)));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultList<UserModel>> FindAll()
        {
            ResultList<UserModel> result = new ResultList<UserModel>();
            try
            {
                result = _mapper.Map<ResultList<UserModel>>(await _userRepository.FindAll());
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<UserModel>> FindByID(int id)
        {
            ResultEntity<UserModel> result = new ResultEntity<UserModel>();
            try
            {
                result = _mapper.Map<ResultEntity<UserModel>>(await _userRepository.FindByID(id));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<UserModel>> Update(UserModel entity)
        {
            ResultEntity<UserModel> result = new ResultEntity<UserModel>();
            try
            {
                result = _mapper.Map<ResultEntity<UserModel>>(await _userRepository.Update(_mapper.Map<UserEntity>(entity)));
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
