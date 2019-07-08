using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model
{
    public class EmployerAllModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public string Rfc { get; set; }
        public int RolId { get; set; }
        public string RolNombre { get; set; }
        public int InstitucionId { get; set; }
        public string InstitucionNombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioMod { get; set; }
        public string Estado { get; set; }
    }
}