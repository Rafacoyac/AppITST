using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class InstitutionData
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


        public static List<InstitutionRegisterAllModel> Mostrar(string u)
        {
            using (var Contexto = new appruebaEntities())
            {



                if (u == "SuperPowerUser")
                {
                    var Resultado = (from Institution in Contexto.Institutions
                                     where Institution.Status == "1" && Institution.UserCreation == u
                                     select new InstitutionRegisterAllModel
                                     {
                                         InstitutionID = Institution.InstitutionID,
                                         Name = Institution.Name,
                                         Direction = Institution.Direction,
                                         Phone = Institution.Phone,
                                         EducationLevelID = Institution.EducationLevelID,
                                         Logo = Institution.Logo,
                                         Director = Institution.Director

                                     }).ToList();
                    return Resultado;

                }
                else
                {
                    var Resultado = (from Institution in Contexto.Institutions
                                     where Institution.Status == "1" && Institution.UserCreation == u
                                     select new InstitutionRegisterAllModel
                                     {
                                         InstitutionID = Institution.InstitutionID,
                                         Name = Institution.Name,
                                         Direction = Institution.Direction,
                                         Phone = Institution.Phone,
                                         EducationLevelID = Institution.EducationLevelID,
                                         Logo = Institution.Logo,
                                         Director = Institution.Director

                                     }).ToList();
                    return Resultado;

                }


            }
        }


        public static Boolean Crear(string nombre, string direccion, string phone, int nivel, string director, string user)
        {
            appruebaEntities data = new appruebaEntities();
            Boolean existe = false;
            var i = new Institution
            {
                Name = nombre,
                Direction = direccion,
                Phone = phone,
                EducationLevelID = nivel,
                Logo = "",
                Director = director,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = "Default",
                UserModification = "Default",
                Status = "1"
            };
            data.Institutions.Add(i);
            data.SaveChanges();
            if (i != null)
            {
                existe = true;

            }
            return existe;

        }


        public static List<InstitutionRegisterAllModel> UpdateShow(int id)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from Institution in Contexto.Institutions
                                 where Institution.InstitutionID == id
                                 select new InstitutionRegisterAllModel
                                 {
                                     InstitutionID = Institution.InstitutionID,
                                     Name = Institution.Name,
                                     Direction = Institution.Direction,
                                     Phone = Institution.Phone,
                                     EducationLevelID = Institution.EducationLevelID,
                                     Logo = Institution.Logo,
                                     Director = Institution.Director
                                 }).ToList();

                return Resultado;
            }
        }


        public static Boolean UpdateRegister(int id, string name, string direccion, string phone, int nivel, string logo, string director, string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                Boolean existe = false;
                appruebaEntities data = new appruebaEntities();
                var consulta = data.Institutions.First(a => a.InstitutionID == id);
                if (consulta != null)
                {
                    consulta.Name = name;
                    consulta.Direction = direccion;
                    consulta.Phone = phone;
                    consulta.EducationLevelID = nivel;
                    consulta.Logo = logo;
                    consulta.Director = director;
                    consulta.DateTimeModification = DateTime.Now;
                    consulta.UserModification = user;

                    data.SaveChanges();
                    existe = true;
                }

                return existe;
            }
        }



        public static Boolean UpdateRegisterUser(int id, string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                Boolean existe = false;
                appruebaEntities data = new appruebaEntities();
                var consulta = data.Institutions.First(a => a.InstitutionID == id);
                if (consulta != null)
                {

                    consulta.UserCreation = user;

                    data.SaveChanges();
                    existe = true;
                }

                return existe;
            }
        }

        public static Boolean Eliminar(int id)
        {
            Boolean existe = false;
            appruebaEntities data = new appruebaEntities();
            var consulta = data.Institutions.First(i => i.InstitutionID == id);

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