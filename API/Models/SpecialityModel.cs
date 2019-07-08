using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class SpecialityModel
    {
        public int SpecialityId { get; set; }
        public string Nombre { get; set; }
        public int InstitucionId { get; set; }
    }
}