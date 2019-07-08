using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model.Api
{
    public class PerfilModel
    {
        //public int StudentsID { get; set; }
        public string Enrollment { get; set; }
        public string Name { get; set; }
        public string LastNameP { get; set; }
        public string LastNameM { get; set; }

        public string Grade { get; set; }
        public string Groups { get; set; }

        public string Institution { get; set; }
        
       /* public string Password { get; set; }
        public System.DateTime DateTimeCreation { get; set; }
        public System.DateTime DateTimeModification { get; set; }
        public string UserCreation { get; set; }
        public string UserModification { get; set; }
        public string Status { get; set; }

        public virtual Group Group { get; set; }
        public virtual Institution Institution { get; set; }*/
    }
}