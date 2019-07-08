using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Models
{
    public class ClassroomModel : ApiController
    {
       public int ClassroomId { get; set; }
       public string Clave { get; set; }
       public string Nombre { get; set; }
       public string Descripcion { get; set; }
       public int Institucion { get; set; }
       public int TipoAula { get; set; }
    }
}
