using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class ClassroomData
    {
        public static Boolean Crear(string clave, string nombre, string descripcion, int intitutoId, int tipoAula, string user)
        {
            appruebaEntities data = new appruebaEntities();
            Boolean existe = false;
            var c = new Classroom
            {
                Clave = clave,
                Name = nombre,
                Description = descripcion,
                InstitutionID = intitutoId,
                ClassRoomTypeID = tipoAula,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Classrooms.Add(c);
            data.SaveChanges();

            if (c != null)
                existe = true;


            return existe;
        }
       

        public static List<ClassroomAllModel> Mostrar(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from classroom in Contexto.Classrooms
                                     join institucion in Contexto.Institutions
                                     on classroom.InstitutionID equals institucion.InstitutionID
                                     join classroomtype in Contexto.ClassRoomTypes on classroom.ClassRoomTypeID equals classroomtype.ClassRoomTypeID
                                     where classroom.Status == "1"
                                     select new ClassroomAllModel
                                     {
                                         Id = classroom.ClassroomID,
                                         Clave = classroom.Clave,
                                         Nombre = classroom.Name,
                                         Descripcion = classroom.Description,
                                         InstitucionNombre = institucion.Name,
                                         NombreAula = classroomtype.Name,
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from classroom in Contexto.Classrooms
                                     join institucion in Contexto.Institutions
                                     on classroom.InstitutionID equals institucion.InstitutionID
                                     join classroomtype in Contexto.ClassRoomTypes on classroom.ClassRoomTypeID equals classroomtype.ClassRoomTypeID
                                     where classroom.Status == "1" && classroom.UserCreation.Equals(user)
                                     select new ClassroomAllModel
                                     {
                                         Id = classroom.ClassroomID,
                                         Clave = classroom.Clave,
                                         Nombre = classroom.Name,
                                         Descripcion = classroom.Description,
                                         InstitucionNombre = institucion.Name,
                                         NombreAula = classroomtype.Name,
                                     }).ToList();
                    return Resultado;
                }

            }
        }

        public static List<ClassroomAllModel> MostrarUpdate(int id)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from classroom in Contexto.Classrooms
                                 join institucion in Contexto.Institutions
                                 on classroom.InstitutionID equals institucion.InstitutionID
                                 join classroomtype in Contexto.ClassRoomTypes on classroom.ClassRoomTypeID equals classroomtype.ClassRoomTypeID
                                 where classroom.ClassroomID==id
                                 select new ClassroomAllModel
                                 {
                                     Id = classroom.ClassroomID,
                                     Clave = classroom.Clave,
                                     Nombre = classroom.Name,
                                     Descripcion = classroom.Description,
                                     InstitucionId=institucion.InstitutionID,
                                     InstitucionNombre = institucion.Name,
                                     TipoAula=classroom.ClassRoomTypeID,
                                     NombreAula = classroomtype.Name
                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Atualizar(int Id, string Clave, string Nombre, string Descripcion, int InstitucionId, int TipoAula, string user)
        {
            Boolean existe = false;

            appruebaEntities data = new appruebaEntities();
            var consulta = data.Classrooms.First(d => d.ClassroomID == Id);
            if (consulta != null)
            {
                consulta.Clave = Clave;
                consulta.Name = Nombre;
                consulta.Description = Descripcion;
                consulta.InstitutionID = InstitucionId;
                consulta.ClassRoomTypeID = TipoAula;
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
            var consulta = data.Classrooms.First(d => d.ClassroomID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        
        public static List<ClassroomTypeAllModel> ObtenerAula()
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from classroomType in Contexto.ClassRoomTypes 
                                 select new ClassroomTypeAllModel
                                 {
                                     Id=classroomType.ClassRoomTypeID,
                                     Nombre = classroomType.Name
                                 }).ToList();
                return Resultado;
            }
        }

        public static List<InstitutionAllModel> ObtenerInstitucion(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from Institution in Contexto.Institutions where Institution.Status=="1" && Institution.UserCreation.Equals(user)

                                 select new InstitutionAllModel
                                 {
                                     Id = Institution.InstitutionID,
                                     Nombre = Institution.Name
                                 }).ToList();
                return Resultado;
            }
        }
    }
}