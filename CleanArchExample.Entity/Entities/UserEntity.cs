using CleanArchExample.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchExample.Entity.Entities
{
    [Table("Users")]
    public class UserEntity: BaseEntity
    {
       
        [Column("Name")]
        [MaxLength(255)]
        public string Name { set; get; }
        [Column("Username")]
        [MaxLength(255)]
        public string Username { set; get; }
        [Column("Password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [Column("User_Type_ID")]
        [ForeignKey("UserType")]
        public int UserTypeID { set; get; }
        public UserTypeEntity UserType { set; get; }
    }
}
