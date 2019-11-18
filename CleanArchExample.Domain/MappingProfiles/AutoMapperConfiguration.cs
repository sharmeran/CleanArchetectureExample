using AutoMapper;
using CleanArchExample.Domain.Models;
using CleanArchExample.Entity.Common.Entities;
using CleanArchExample.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchExample.Domain.MappingProfiles
{
   public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration(cfg =>
            {
               
                cfg.AddProfile(new GenericMappingProfile());

            });
        }
    }
}
