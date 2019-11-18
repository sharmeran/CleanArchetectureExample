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
   public class EmployeeDomain : IEmployeeDomain
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeDomain(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<ResultEntity<EmployeeModel>> Add(EmployeeModel entity)
        {
            ResultEntity<EmployeeModel> result = new ResultEntity<EmployeeModel>();
            try
            {
                result = _mapper.Map<ResultEntity<EmployeeModel>>(await _employeeRepository.Insert(_mapper.Map<EmployeeEntity>(entity)));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<EmployeeModel>> Delete(EmployeeModel entity)
        {
            ResultEntity<EmployeeModel> result = new ResultEntity<EmployeeModel>();
            try
            {
                result = _mapper.Map<ResultEntity<EmployeeModel>>(await _employeeRepository.Delete(_mapper.Map<EmployeeEntity>(entity)));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultList<EmployeeModel>> FindAll()
        {
            ResultList<EmployeeModel> result = new ResultList<EmployeeModel>();
            try
            {
                result = _mapper.Map<ResultList<EmployeeModel>>(await _employeeRepository.FindAll());
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<EmployeeModel>> FindByID(int id)
        {
            ResultEntity<EmployeeModel> result = new ResultEntity<EmployeeModel>();
            try
            {
                result = _mapper.Map<ResultEntity<EmployeeModel>>(await _employeeRepository.FindByID(id));
            }
            catch (Exception ex)
            {

                result.Status = StatusTypeEnum.Exception;
                result.MessageEnglish = ex.Message;
                result.DetailsEnglish = ex.StackTrace;
            }
            return result;
        }

        public async Task<ResultEntity<EmployeeModel>> Update(EmployeeModel entity)
        {
            ResultEntity<EmployeeModel> result = new ResultEntity<EmployeeModel>();
            try
            {
                result = _mapper.Map<ResultEntity<EmployeeModel>>(await _employeeRepository.Update(_mapper.Map<EmployeeEntity>(entity)));
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
