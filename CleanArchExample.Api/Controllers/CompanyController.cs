using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchExample.Domain.Interfaces;
using CleanArchExample.Domain.Models;
using CleanArchExample.Entity.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanArchExample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
       

        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyDomain _companyDomain;

        public CompanyController(ILogger<CompanyController> logger, ICompanyDomain companyDomain)
        {
            _logger = logger;
            _companyDomain = companyDomain;
        }

        [HttpGet]
        [Route("FindAll")]
        public async Task< ResultList<CompanyModel>>FindAll()
        {
            return await _companyDomain.FindAll();           
        }

        [HttpGet]
        [Route("FindByID/{id}")]
        public async Task<ResultEntity<CompanyModel>> FindByID(int id)
        {
            return await _companyDomain.FindByID(id);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ResultEntity<CompanyModel>> Add(CompanyModel companyModel)
        {
            return await _companyDomain.Add(companyModel);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ResultEntity<CompanyModel>> Update(CompanyModel companyModel)
        {
            return await _companyDomain.Update(companyModel);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ResultEntity<CompanyModel>> Delete(CompanyModel companyModel)
        {
            return await _companyDomain.Delete(companyModel);
        }
    }
}
