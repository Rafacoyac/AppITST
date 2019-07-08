using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class SpecialityData
    {
        public static Boolean Crear(string Nombre, int InstitucionId, string user)
        {
            appruebaEntities data = new appruebaEntities();
            Boolean existe = false;
            var g = new Speciality
            {
                Name = Nombre,
                InstitutionID=InstitucionId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Specialities.Add(g);
            data.SaveChanges();

            if (g != null)
                existe = true;

            return existe;
        }


        public static List<SpecialityAllModel> Mostrar(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from speciality in Contexto.Specialities
                                     join institucion in Contexto.Institutions
                                     on speciality.InstitutionID equals institucion.InstitutionID
                                     where speciality.Status == "1"
                                     select new SpecialityAllModel
                                     {
                                         Id = speciality.SpecialityID,
                                         Nombre = speciality.Name,
                                         InstitucionNombre = institucion.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from speciality in Contexto.Specialities
                                     join institucion in Contexto.Institutions
                                     on speciality.InstitutionID equals institucion.InstitutionID
                                     where speciality.Status == "1" && speciality.UserCreation.Equals(user)
                                     select new SpecialityAllModel
                                     {
                                         Id = speciality.SpecialityID,
                                         Nombre = speciality.Name,
                                         InstitucionNombre = institucion.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }

        public static List<SpecialityAllModel> MostrarUpdate(int Id)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from speciality in Contexto.Specialities
                                 join institucion in Contexto.Institutions
                                 on speciality.InstitutionID equals institucion.InstitutionID
                                 where speciality.SpecialityID==Id
                                 select new SpecialityAllModel
                                 {
                                     Id = speciality.SpecialityID,
                                     Nombre = speciality.Name,
                                     InstitucionId = speciality.InstitutionID,
                                     InstitucionNombre=institucion.Name
                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Actualizar(int Id, string Nombre, int InstitucionId, string user)
        {
            Boolean existe = false;

            appruebaEntities data = new appruebaEntities();
            var consulta = data.Specialities.First(d => d.SpecialityID == Id);
            if (consulta != null)
            {
                consulta.Name=Nombre;
                consulta.InstitutionID =InstitucionId;
                consulta.DateTimeModification = DateTime.Now;
                consulta.UserModification = user;
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            appruebaEntities data = new appruebaEntities();
            var consulta = data.Specialities.First(d => d.SpecialityID == Id);
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