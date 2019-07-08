using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public string Telefono { get; set; }
        public int InstitucionId { get; set; }
        public int GrupoId { get; set; }
        public string Password { get; set; }
        public int Grado { get; set; }
        
    }
}