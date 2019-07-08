using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class LessonModel
    {
        public int LessonId { get; set; }
        public string Dia { get; set; }
        public int EmpleadosId { get; set; }
        public TimeSpan HoraIn { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int AulaId { get; set; }
        public int MateriaId { get; set; }
        //public int GrupoId { get; set; }
        
    }
}