using CleanArchExample.Domain.Domains;
using CleanArchExample.Domain.Interfaces;
using CleanArchExample.Repository.Interfaces;
using CleanArchExample.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchExample.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICompanyDomain, CompanyDomain>();
            services.AddScoped<IEmployeeDomain, EmployeeDomain>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserTypeDomain, UserTypeDomain>();



            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();

        }
    }
}
