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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserDomain _userDomain;

        public UserController(ILogger<UserController> logger, IUserDomain userDomain)
        {
            _logger = logger;
            _userDomain = userDomain;
        }

        [HttpGet]
        [Route("FindAll")]
        public async Task<ResultList<UserModel>> FindAll()
        {
            return await _userDomain.FindAll();
        }

        [HttpGet]
        [Route("FindByID/{id}")]
        public async Task<ResultEntity<UserModel>> FindByID(int id)
        {
            return await _userDomain.FindByID(id);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ResultEntity<UserModel>> Add(UserModel UserModel)
        {
            return await _userDomain.Add(UserModel);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ResultEntity<UserModel>> Update(UserModel UserModel)
        {
            return await _userDomain.Update(UserModel);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ResultEntity<UserModel>> Delete(UserModel UserModel)
        {
            return await _userDomain.Delete(UserModel);
        }
    }
}