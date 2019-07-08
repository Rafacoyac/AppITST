using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Model.Api
{
    public class LessonWeekModel
    {
        public string Enrollment { get; set; }
        public string StudenName {get; set; }
        public string StudenFirstNP { get; set; }
        public string StudenLastNM { get; set; }
        public string Grade { get; set; }
        public string SubjectsKey { get; set; }
        public string SubjectsName { get; set; }
        public string Days { get; set; }
        public TimeSpan HoursStart { get; set; }
        public TimeSpan HoursFinished { get; set; }
        public string Grou { get; set; }
        public string EmplyerName { get; set; }
        public string EmplyerFirstNP { get; set; }
        public string EmplyerFirstNM { get; set; }
        public string Clssroom { get; set; }

    }
}