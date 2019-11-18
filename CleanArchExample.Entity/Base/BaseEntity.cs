using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CleanArchExample.Entity.Base
{
  public class BaseEntity
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("Created_By")]
        public int CreatedBy { set; get; }
        [Column("Updated_By")]
        public int UpdatedBy { set; get; }
        [Column("Created_On")]
        public DateTime CreatedOn { set; get; }
        [Column("Updated_On")]
        public DateTime UpdatedOn { set; get; }
    }
}
