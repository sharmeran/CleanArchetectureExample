using CleanArchExample.Entity.Entities;
using CleanArchExample.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchExample.Repository.Interfaces
{
    public interface ICompanyRepository : BaseRepositoryInterface<CompanyEntity>
    {
    }
}
