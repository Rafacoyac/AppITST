using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class InstitutionsRegisterModel
    {
        public int InstitutionID { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public string Phone { get; set; }
        public int EducationLevelID { get; set; }
        public string Logo { get; set; }
        public string Director { get; set; }
        public string UserCreation { get; set; }
    }
}