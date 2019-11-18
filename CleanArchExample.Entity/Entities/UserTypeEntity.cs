using CleanArchExample.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchExample.Entity.Entities
{
    [Table("User_Type")]
    public class UserTypeEntity: BaseEntity
    {
       
        [Column("Name")]
        [MaxLength(255)]
        public string Name { set; get; }

        public UserEntity User { set; get; }
    }
}
