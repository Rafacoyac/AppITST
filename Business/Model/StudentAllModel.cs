using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model
{
    public class StudentAllModel
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public string Telefono { get; set; }
        public int InstitucionId { get; set; }
        public string InstitucionNombre { get; set; }
        public int GrupoId { get; set; }
        public string GrupoNombre { get; set; }
        public string Password { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioMod { get; set; }
        public string Estado { get; set; }
        public int GradoId { get; set; }
        public string GradoNombre { get; set; }
    }
}