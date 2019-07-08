using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class EducationLeverData
    {
        public static List<EducationLevelAllmodel> ObtenerNivel()
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from education in Contexto.EducationLevels

                                 select new EducationLevelAllmodel
                                 {
                                     Id = education.EducationLevelID,
                                     Nombre = education.Level
                                 }).ToList();
                return Resultado;
            }
        }
    }
}