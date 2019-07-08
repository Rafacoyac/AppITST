using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class EmployerData
    {
        public static Boolean Crear(string Nombre, string Apellidop, string Apellidom, string Rfc, int RolId, int InstitucionId, string user)
        {
            appruebaEntities data = new appruebaEntities();
            Boolean existe = false;
            var s = new Employer
            {
                Name = Nombre,
                LastNameP= Apellidop,
                LastNameM = Apellidom,
                RFC = Rfc,
                RolesID=RolId,
                InstitutionID=InstitucionId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Employers.Add(s);
            data.SaveChanges();

            if (s != null)
                existe = true;

            return existe;
        }


        public static List<EmployerAllModel> Mostrar(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from employer in Contexto.Employers
                                     join rol in Contexto.Roles on employer.RolesID equals rol.RolesID
                                     join institucion in Contexto.Institutions on employer.InstitutionID equals institucion.InstitutionID
                                     where employer.Status == "1"
                                     select new EmployerAllModel
                                     {
                                         Id = employer.EmployersID,
                                         Nombre = employer.Name,
                                         Apellidop = employer.LastNameP,
                                         Apellidom = employer.LastNameM,
                                         Rfc = employer.RFC,
                                         RolNombre = rol.Name,
                                         InstitucionNombre = institucion.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {

                    var Resultado = (from employer in Contexto.Employers
                                     join rol in Contexto.Roles on employer.RolesID equals rol.RolesID
                                     join institucion in Contexto.Institutions on employer.InstitutionID equals institucion.InstitutionID
                                     where employer.Status == "1" && employer.UserCreation.Equals(user)
                                     select new EmployerAllModel
                                     {
                                         Id = employer.EmployersID,
                                         Nombre = employer.Name,
                                         Apellidop = employer.LastNameP,
                                         Apellidom = employer.LastNameM,
                                         Rfc = employer.RFC,
                                         RolNombre = rol.Name,
                                         InstitucionNombre = institucion.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }

        public static List<EmployerAllModel> MostrarActualizar(int id)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from employer in Contexto.Employers
                                 join rol in Contexto.Roles on employer.RolesID equals rol.RolesID
                                 join institucion in Contexto.Institutions on employer.InstitutionID equals institucion.InstitutionID
                                 where employer.EmployersID==id
                                 select new EmployerAllModel
                                 {
                                     Id = employer.EmployersID,
                                     Nombre = employer.Name,
                                     Apellidop = employer.LastNameP,
                                     Apellidom = employer.LastNameM,
                                     Rfc = employer.RFC,
                                     RolId=employer.RolesID,
                                     RolNombre = rol.Name,
                                     InstitucionId=employer.InstitutionID,
                                     InstitucionNombre = institucion.Name
                                 }).ToList();
                return Resultado;
            }
        }


        public static Boolean Actualizar(int Id, string Nombre, string Apellidop, string Apellidom, string Rfc, int RolId, int InstitucionId,string user)
        {
            Boolean existe = false;

            appruebaEntities data = new appruebaEntities();
            var consulta = data.Employers.First(d => d.EmployersID == Id);
            if (consulta != null)
            {
                consulta.Name=Nombre;
                consulta.LastNameP =Apellidop;
                consulta.LastNameM =Apellidom;
                consulta.RFC = Rfc;
                consulta.RolesID = RolId;
                consulta.InstitutionID = InstitucionId;
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
            var consulta = data.Employers.First(d => d.EmployersID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        public static List<RolAllModel> ObtenerRol()
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from rol in Contexto.Roles

                                 select new RolAllModel
                                 {
                                     Id = rol.RolesID,
                                     Nombre = rol.Name
                                 }).ToList();
                return Resultado;
            }
        }
    }
}