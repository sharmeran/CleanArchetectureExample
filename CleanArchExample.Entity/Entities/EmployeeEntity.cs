using CleanArchExample.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchExample.Entity.Entities
{
    [Table("Employee")]
    public class EmployeeEntity: BaseEntity
    {
       
        [Column("Name")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Column("Company_ID")]
        [ForeignKey("Company")]
        public int CompanyID { set; get; }
        public CompanyEntity Company { get; set; }
    }
}
