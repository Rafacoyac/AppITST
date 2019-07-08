using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model
{
    public class DegreeSubjectAllModel
    {
        public int Id { get; set; }
        public int DegreeId { get; set; }
        public string DegreeNombre { get; set; }
        public int SubjectId { get; set; }
        public string SubjectNombre { get; set; }
    }
}