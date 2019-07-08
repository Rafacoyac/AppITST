using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model
{
    public class AdminAllModel
    {
        public int AdminsID { get; set; }
        public string Name { get; set; }
        public string LastNameP { get; set; }
        public string LastNameM { get; set; }
        public string Users { get; set; }
        public string Pass { get; set; }
        public int InstitutionID { get; set; }
        public string Photo { get; set; }
    }
}