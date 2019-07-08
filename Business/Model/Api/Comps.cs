using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model.Api
{
    public class Comps
    {
        public string Matricula;//{ get; set; }
        
        public Comps() { }

        public Comps(string x)
        {
            Matricula = x;
        }

        public string getMatricula()
        {
            return Matricula;
        }

        public void setMatricula(string usuario)
        {
            Matricula = usuario;
        }
        
    }
}