using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class EmployerModel
    {
        public int EmployerId { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public string Rfc { get; set; }
        public int RolesId { get; set; }
        public int InstitucionId { get; set; }
    }
}