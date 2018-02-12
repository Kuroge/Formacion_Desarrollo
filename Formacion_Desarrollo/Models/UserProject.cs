using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formacion_Desarrollo.Models
{
    public class UserProject
    {
        public long UserId { get; set; }

        public User User { get; set; }

        public long ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
