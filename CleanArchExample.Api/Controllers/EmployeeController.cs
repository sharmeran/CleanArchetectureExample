using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchExample.Domain.Interfaces;
using CleanArchExample.Domain.Models;
using CleanArchExample.Entity.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanArchExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeDomain _employeeDomain;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeDomain employeeDomain)
        {
            _logger = logger;
            _employeeDomain = employeeDomain;
        }

        [HttpGet]
        [Route("FindAll")]
        public async Task<ResultList<EmployeeModel>> FindAll()
        {
            return await _employeeDomain.FindAll();
        }

        [HttpGet]
        [Route("FindByID/{id}")]
        public async Task<ResultEntity<EmployeeModel>> FindByID(int id)
        {
            return await _employeeDomain.FindByID(id);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ResultEntity<EmployeeModel>> Add(EmployeeModel EmployeeModel)
        {
            return await _employeeDomain.Add(EmployeeModel);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ResultEntity<EmployeeModel>> Update(EmployeeModel EmployeeModel)
        {
            return await _employeeDomain.Update(EmployeeModel);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ResultEntity<EmployeeModel>> Delete(EmployeeModel EmployeeModel)
        {
            return await _employeeDomain.Delete(EmployeeModel);
        }
    }
}