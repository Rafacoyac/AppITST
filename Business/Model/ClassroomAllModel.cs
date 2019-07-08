using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model
{
    public class ClassroomAllModel
    {
       public int Id { get; set; }
       public string Clave { get; set; }
       public string Nombre { get; set; }
       public string Descripcion { get; set; }
       public int InstitucionId { get; set; }
       public string InstitucionNombre { get; set; }
       public int TipoAula { get; set; }
       public string NombreAula { get; set; }
    }
}