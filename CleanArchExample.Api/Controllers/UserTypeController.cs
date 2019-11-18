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
    public class UserTypeController : ControllerBase
    {
        private readonly ILogger<UserTypeController> _logger;
        private readonly IUserTypeDomain _userTypeDomain;

        public UserTypeController(ILogger<UserTypeController> logger, IUserTypeDomain userTypeDomain)
        {
            _logger = logger;
            _userTypeDomain = userTypeDomain;
        }

        [HttpGet]
        [Route("FindAll")]
        public async Task<ResultList<UserTypeModel>> FindAll()
        {
            return await _userTypeDomain.FindAll();
        }

        [HttpGet]
        [Route("FindByID/{id}")]
        public async Task<ResultEntity<UserTypeModel>> FindByID(int id)
        {
            return await _userTypeDomain.FindByID(id);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ResultEntity<UserTypeModel>> Add(UserTypeModel UserTypeModel)
        {
            return await _userTypeDomain.Add(UserTypeModel);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ResultEntity<UserTypeModel>> Update(UserTypeModel UserTypeModel)
        {
            return await _userTypeDomain.Update(UserTypeModel);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ResultEntity<UserTypeModel>> Delete(UserTypeModel UserTypeModel)
        {
            return await _userTypeDomain.Delete(UserTypeModel);
        }
    }
}