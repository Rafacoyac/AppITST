using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class StudentData
    {
        public static Boolean Crear(string Matricula, string Nombre, string Apellidop, string Apellidom, string Telefono, int InstitucionId, int GrupoId, int Grado, string user)
        {
            appruebaEntities data = new appruebaEntities();
            Boolean existe = false;
            var s = new Student
            {
                Enrollment=Matricula,
                Name = Nombre,
                LastNameP=Apellidop,
                LastNameM=Apellidom,
                Phone=Telefono,
                InstitutionID=InstitucionId,
                GroupsID=GrupoId,
                Password=Matricula,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1",
                DegreeId=Grado
                
            };
            data.Students.Add(s);
            data.SaveChanges();

            if (s != null)
                existe = true;

            return existe;
        }


        public static List<StudentAllModel> Mostrar(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from student in Contexto.Students
                                     join inst in Contexto.Institutions on student.InstitutionID equals inst.InstitutionID
                                     join gro in Contexto.Groups on student.GroupsID equals gro.GroupsID
                                     join gra in Contexto.Degrees on student.DegreeId equals gra.DegreeID
                                     where student.Status == "1" 
                                     select new StudentAllModel
                                     {
                                         Id = student.StudentsID,
                                         Matricula = student.Enrollment,
                                         Nombre = student.Name,
                                         Apellidop = student.LastNameP,
                                         Apellidom = student.LastNameM,
                                         Telefono = student.Phone,
                                         InstitucionNombre = inst.Name,
                                         GrupoNombre = gro.Name,
                                         GradoNombre = gra.Name,
                                         Password = student.Password
                                         
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from student in Contexto.Students
                                     join inst in Contexto.Institutions on student.InstitutionID equals inst.InstitutionID
                                     join gro in Contexto.Groups on student.GroupsID equals gro.GroupsID
                                     where student.Status == "1" && student.UserCreation.Equals(user)
                                     join gra in Contexto.Degrees on student.DegreeId equals gra.DegreeID
                                     select new StudentAllModel
                                     {
                                         Id = student.StudentsID,
                                         Matricula = student.Enrollment,
                                         Nombre = student.Name,
                                         Apellidop = student.LastNameP,
                                         Apellidom = student.LastNameM,
                                         Telefono = student.Phone,
                                         InstitucionNombre = inst.Name,
                                         GrupoNombre = gro.Name,
                                         GradoNombre = gra.Name,
                                         Password = student.Password

                                     }).ToList();
                    return Resultado;
                }
            }
        }

        public static List<StudentAllModel> MostrarActualizar(int id)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from student in Contexto.Students
                                 join inst in Contexto.Institutions on student.InstitutionID equals inst.InstitutionID
                                 join gro in Contexto.Groups on student.GroupsID equals gro.GroupsID
                                 join gra in Contexto.Degrees on student.DegreeId equals gra.DegreeID
                                 where student.StudentsID==id
                                 select new StudentAllModel
                                 {
                                     Id = student.StudentsID,
                                     Matricula = student.Enrollment,
                                     Nombre = student.Name,
                                     Apellidop = student.LastNameP,
                                     Apellidom = student.LastNameM,
                                     Telefono = student.Phone,
                                     InstitucionId=student.InstitutionID,
                                     InstitucionNombre = inst.Name,
                                     GrupoId=student.GroupsID,
                                     GrupoNombre = inst.Name,
                                     Password = student.Password,
                                     GradoId = gra.DegreeID,
                                     GradoNombre=gra.Name

                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Actualizar(int Id, string Matricula, string Nombre, string Apellidop, string Apellidom, string Telefono, int InstitucionId, int GrupoId, int grado, string user)
        {
            Boolean existe = false;

            appruebaEntities data = new appruebaEntities();
            var consulta = data.Students.First(d => d.StudentsID == Id);
            if (consulta != null)
            {
                consulta.Enrollment=Matricula;
                consulta.Name =Nombre;
                consulta.LastNameP = Apellidop;
                consulta.LastNameM = Apellidom;
                consulta.Phone = Telefono;
                consulta.InstitutionID = InstitucionId;
                consulta.GroupsID = GrupoId;
                // consulta.Password = student.Password;
                consulta.DegreeId = grado;
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
            var consulta = data.Students.First(d => d.StudentsID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        public static List<GroupAllModel> ObtenerGroup(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from groups in Contexto.Groups where groups.Status=="1" && groups.UserCreation.Equals(user)
                                 select new GroupAllModel
                                 {
                                     Id = groups.GroupsID,
                                     Nombre = groups.Name
                                 }).ToList();
                return Resultado;
            }
        }

        public static List<DegreeAllModel> ObtenerGrado(string user)
        {
            using (var Contexto = new appruebaEntities())
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
}