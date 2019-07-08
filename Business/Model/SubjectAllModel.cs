using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model
{
    public class SubjectAllModel
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int CarreraId { get; set; }
        public string CarreraNombre { get; set; }
        public int EspecialidadId { get; set; }
        public string EspecialidadNombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaMod { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioMod { get; set; }
        public string Estado { get; set; }
    }
}