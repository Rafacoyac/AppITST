using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Model;
using Data;

namespace Business.Data
{
    public class DegreeData
    {
        public static Boolean Crear(string Nombre,string user)
        {
            appruebaEntities data = new appruebaEntities();
            Boolean existe = false;
            var d = new Degree
            {
                Name = Nombre,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Degrees.Add(d);
            data.SaveChanges();

            if (d != null)
                existe = true;
            
            
            return existe;
        }

        public static List<DegreeAllModel>MostrarUpdate(int Id)
        {
            appruebaEntities data = new appruebaEntities();
            var Resultado = (from degree in data.Degrees
                             where degree.DegreeID == Id
                             select new DegreeAllModel
                             {
                                 Id=degree.DegreeID,
                                 Nombre = degree.Name
                             }).ToList();
            return Resultado;
        }

        public static Boolean Actualizar(int Id, string Nombre,string user)
        {
            Boolean existe = false;

            appruebaEntities data = new appruebaEntities();
            var consulta = data.Degrees.First(d => d.DegreeID == Id);
            if (consulta != null)
            {
                consulta.Name = Nombre;
                consulta.DateTimeModification = DateTime.Now;
                consulta.UserModification = user;
                data.SaveChanges();
                existe = true;
            }
          
            return existe;
        }
        

        public static List<DegreeAllModel> Mostrar(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from degree in Contexto.Degrees
                                     where degree.Status == "1"
                                     select new DegreeAllModel
                                     {
                                         Id = degree.DegreeID,
                                         Nombre = degree.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from degree in Contexto.Degrees
                                     where degree.Status == "1" && degree.UserCreation.Equals(user)
                                     select new DegreeAllModel
                                     {
                                         Id = degree.DegreeID,
                                         Nombre = degree.Name
                                     }).ToList();
                    return Resultado;
                }
                
            }
        }

        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            appruebaEntities data = new appruebaEntities();
            var consulta = data.Degrees.First(d => d.DegreeID == Id);
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
