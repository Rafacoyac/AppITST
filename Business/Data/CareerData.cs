using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class CareerData
    {
        public static Boolean Crear(string clave, string nombre, int institutoId, string user)
        {

            appruebaEntities data = new appruebaEntities();
            Boolean existe = false;
            var ca = new Career
            {
                Key = clave,
                Name = nombre,
                InstitutionID = institutoId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Careers.Add(ca);
            data.SaveChanges();

            if (ca != null)
                existe = true;

            return existe;
        }


        public static List<CareerAllModel> Mostrar(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from career in Contexto.Careers
                                     join institucion in Contexto.Institutions
                                     on career.InstitutionID equals institucion.InstitutionID
                                     where career.Status == "1" 
                                     select new CareerAllModel
                                     {
                                         Id = career.CareersID,
                                         Clave = career.Key,
                                         Nombre = career.Name,
                                         InstitucionNombre = institucion.Name,
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from career in Contexto.Careers
                                     join institucion in Contexto.Institutions
                                     on career.InstitutionID equals institucion.InstitutionID
                                     where career.Status == "1" && career.UserCreation.Equals(user)
                                     select new CareerAllModel
                                     {
                                         Id = career.CareersID,
                                         Clave = career.Key,
                                         Nombre = career.Name,
                                         InstitucionNombre = institucion.Name,
                                     }).ToList();
                    return Resultado;
                }
                
            }
        }

        public static List<CareerAllModel> MostrarActualizar(int id)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from career in Contexto.Careers
                                 join institucion in Contexto.Institutions
                                 on career.InstitutionID equals institucion.InstitutionID
                                 where career.CareersID == id
                                 select new CareerAllModel
                                 {
                                     Id = career.CareersID,
                                     Clave = career.Key,
                                     Nombre = career.Name,
                                     InstitucionId=career.InstitutionID,
                                     InstitucionNombre = institucion.Name,
                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Actualizar(int Id, string Clave, string Nombre, int InstitucionId, string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                Boolean existe = false;

                appruebaEntities data = new appruebaEntities();
                var consulta = data.Careers.First(d => d.CareersID == Id);
                if (consulta != null)
                {
                    consulta.Key=Clave;
                    consulta.Name = Nombre;
                    consulta.InstitutionID =InstitucionId;
                    consulta.DateTimeModification = DateTime.Now;
                    consulta.UserModification = user;
                    data.SaveChanges();
                    existe = true;
                }

                return existe;
            }
        }
        


        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            appruebaEntities data = new appruebaEntities();
            var consulta = data.Careers.First(d => d.CareersID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

    }
}
