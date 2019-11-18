using CleanArchExample.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchExample.Repository.Common
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<CompanyEntity> CompanyDBSet { set; get; }
        public DbSet<EmployeeEntity> EmployeeDBSet { set; get; }
        public DbSet<UserEntity> UserDBSet { set; get; }
        public DbSet<UserTypeEntity> UserTypeDBSet { set; get; }
    }
}
