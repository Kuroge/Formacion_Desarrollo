using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Formacion_Desarrollo.Models
{
    public abstract class Entity
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("Nombre")]
        public string Name { get; set; }
    }
}
