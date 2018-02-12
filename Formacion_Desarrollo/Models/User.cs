using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Formacion_Desarrollo.Models
{
    [Table("Usuario")]
    public class User : Entity
    {
        [Column("Apellidos")]
        public string LastName{ get; set; }
        [Column("Telefono")]
        public string Phone { get; set; }
        [Column("Cp")]
        public int PostalCode { get; set; }
        public long DepartmentId { get; set; }

        public IList<UserProject> UserProjects { get; set; }
    }
}
