using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Formacion_Desarrollo.Models
{
    [Table("Department")]
    public class Department : Entity
    {
        [Column("Descripcion")]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
