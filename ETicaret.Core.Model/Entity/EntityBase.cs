using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.Model.Entity
{
   public class EntityBase 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int CreateUserID { get; set; }

        public int? UpdateUser { get; set; }

    }
}
