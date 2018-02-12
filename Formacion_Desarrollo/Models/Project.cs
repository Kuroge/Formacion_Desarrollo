using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Formacion_Desarrollo.Models
{
    [Table("Proyecto")]
    public class Project : Entity
    {

        [Column("Descripcion")]
        public string Description { get; set; }
        [Column("FechaInicio")]
        public DateTime StartDate { get; set; }
        [Column("FechaFin")]
        public DateTime EndDate { get; set; }

        public IList<UserProject> UserProjects { get; set; }
    }
}
