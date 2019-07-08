using Business.Model.Api;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data.Api
{
    public class EnrollmentData
    {
        public static string Enrollment(string token)
        {
            
            using (var Contexto = new appruebaEntities())
            {

                var matricula = (from b in Contexto.Autentications
                                 where b.Token.Equals(token)
                                 select new Comps
                                 {
                                     Matricula = b.User
                                 }).FirstOrDefault();

                string a = matricula.Matricula;
                return a;
            }
        }
    }
}