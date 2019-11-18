using AutoMapper;
using CleanArchExample.Domain.Models;
using CleanArchExample.Entity.Common.Entities;
using CleanArchExample.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchExample.Domain.MappingProfiles
{
    public class GenericMappingProfile : Profile
    {
        public GenericMappingProfile()
        {
            CreateMap<CompanyModel, CompanyEntity>();
            CreateMap<CompanyEntity, CompanyModel>();
            CreateMap<ResultEntity<CompanyModel>, ResultEntity<CompanyEntity>>();
            CreateMap<ResultEntity<CompanyEntity>, ResultEntity<CompanyModel>>();
            CreateMap<ResultList<CompanyModel>, ResultList<CompanyEntity>>();
            CreateMap<ResultList<CompanyEntity>, ResultList<CompanyModel>>();

            CreateMap<EmployeeModel, EmployeeEntity>();
            CreateMap<EmployeeEntity, EmployeeModel>();
            CreateMap<ResultEntity<EmployeeModel>, ResultEntity<EmployeeEntity>>();
            CreateMap<ResultEntity<EmployeeEntity>, ResultEntity<EmployeeModel>>();
            CreateMap<ResultList<EmployeeModel>, ResultList<EmployeeEntity>>();
            CreateMap<ResultList<EmployeeEntity>, ResultList<EmployeeModel>>();

            CreateMap<UserModel, UserEntity>();
            CreateMap<UserEntity, UserModel>();
            CreateMap<ResultEntity<UserModel>, ResultEntity<UserEntity>>();
            CreateMap<ResultEntity<UserEntity>, ResultEntity<UserModel>>();
            CreateMap<ResultList<UserModel>, ResultList<UserEntity>>();
            CreateMap<ResultList<UserEntity>, ResultList<UserModel>>();

            CreateMap<UserTypeModel, UserTypeEntity>();
            CreateMap<UserTypeEntity, UserTypeModel>();
            CreateMap<ResultEntity<UserTypeModel>, ResultEntity<UserTypeEntity>>();
            CreateMap<ResultEntity<UserTypeEntity>, ResultEntity<UserTypeModel>>();
            CreateMap<ResultList<UserTypeModel>, ResultList<UserTypeEntity>>();
            CreateMap<ResultList<UserTypeEntity>, ResultList<UserTypeModel>>();
        }
    }
}