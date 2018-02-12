using Formacion_Desarrollo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formacion_Desarrollo.ViewModels
{
    public class VMUser
    {
        public User User { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
