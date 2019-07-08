using Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Models
{
   
    public class SubjectModel
    {
       public int SubjectId { get; set; }
       public string Clave { get; set; }
       public string Nombre { get; set; }
       public int Creditos { get; set; }
       public int CarreraId { get; set; }
       public int EspecialidadId { get; set; }
    }
}