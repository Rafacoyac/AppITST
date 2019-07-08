using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class GroupData
    {
        public static Boolean Crear(string Nombre, string user)
        {
            appruebaEntities data = new appruebaEntities();
            Boolean existe = false;
            var g = new Group
            {
                Name = Nombre,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Groups.Add(g);
            data.SaveChanges();

            if (g != null)
                existe = true;
        
            return existe;
        }

      
        public static List<GroupAllModel> Mostrar(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from grou in Contexto.Groups
                                     where grou.Status == "1"
                                     select new GroupAllModel
                                     {
                                         Id = grou.GroupsID,
                                         Nombre = grou.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from grou in Contexto.Groups
                                     where grou.Status == "1" && grou.UserCreation.Equals(user)
                                     select new GroupAllModel
                                     {
                                         Id = grou.GroupsID,
                                         Nombre = grou.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }
        public static List<GroupAllModel> MostrarUpdate(int Id)
        {
            appruebaEntities data = new appruebaEntities();
            var Resultado = (from groups in data.Groups
                             where groups.GroupsID == Id
                             select new GroupAllModel
                             {
                                 Id = groups.GroupsID,
                                 Nombre = groups.Name
                             }).ToList();
            return Resultado;
        }
        public static Boolean Actualizar(int Id, string Nombre, string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                Boolean existe = false;

                appruebaEntities data = new appruebaEntities();
                var consulta = data.Groups.First(d => d.GroupsID == Id);
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

        }

            public static Boolean Eliminar(int Id)
            {
            Boolean existe = false;

            appruebaEntities data = new appruebaEntities();
            var consulta = data.Groups.First(d => d.GroupsID == Id);
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