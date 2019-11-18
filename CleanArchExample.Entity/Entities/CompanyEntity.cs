using CleanArchExample.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchExample.Entity.Entities
{
    [Table("Company")]
    public class CompanyEntity: BaseEntity
    {
       
        [Column("Name")]
        [MaxLength(255)]
        public string Name { get; set; }
        public ICollection<EmployeeEntity> Employees { get; set; }
    }
}
