using Business.Model;
using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class DegreeSubjectData
    {
        public static Boolean Crear(int DegreeId, int SubjectId, string user)
        {
            appruebaEntities data = new appruebaEntities();
            Boolean existe = false;
            var s = new DegreeSubject
            {
                DegreeID=DegreeId,
                SubjectsID=SubjectId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.DegreeSubjects.Add(s);
            data.SaveChanges();

            if (s != null)
                existe = true;

            return existe;
        }


        public static List<DegreeSubjectAllModel> Mostrar(string user)
        {

            using (var Contexto = new appruebaEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from degreeSubject in Contexto.DegreeSubjects
                                     join subject in Contexto.Subjects on degreeSubject.SubjectsID equals subject.SubjectsID
                                     join degree in Contexto.Degrees on degreeSubject.DegreeID equals degree.DegreeID
                                     select new DegreeSubjectAllModel
                                     {
                                         Id = degreeSubject.DegreeSubjectsID,
                                         DegreeNombre = degree.Name,
                                         SubjectNombre = subject.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from degreeSubject in Contexto.DegreeSubjects
                                     join subject in Contexto.Subjects on degreeSubject.SubjectsID equals subject.SubjectsID
                                     join degree in Contexto.Degrees on degreeSubject.DegreeID equals degree.DegreeID
                                     where degreeSubject.UserCreation.Equals(user)
                                     select new DegreeSubjectAllModel
                                     {
                                         Id = degreeSubject.DegreeSubjectsID,
                                         DegreeNombre = degree.Name,
                                         SubjectNombre = subject.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }


        public static List<DegreeSubjectAllModel> MostrarActualizar(int id)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from degreeSubject in Contexto.DegreeSubjects
                                 join subject in Contexto.Subjects on degreeSubject.SubjectsID equals subject.SubjectsID
                                 join degree in Contexto.Degrees on degreeSubject.DegreeID equals degree.DegreeID
                                 where degreeSubject.DegreeSubjectsID==id
                                 select new DegreeSubjectAllModel
                                 {
                                     Id = degreeSubject.DegreeSubjectsID,
                                     DegreeId=degreeSubject.DegreeID,
                                     DegreeNombre = degree.Name,
                                     SubjectId=degreeSubject.SubjectsID,
                                     SubjectNombre = subject.Name
                                 }).ToList();
                return Resultado;
            }
        }

        public static Boolean Actualizar(int Id, int DegreeId, int SubjectId, string user)
        {
            Boolean existe = false;

            appruebaEntities data = new appruebaEntities();
            var consulta = data.DegreeSubjects.First(d => d.DegreeSubjectsID ==Id);
            if (consulta != null)
            {
                consulta.DegreeID = DegreeId;
                consulta.SubjectsID = SubjectId;
                consulta.DateTimeModification = DateTime.Now;
                consulta.UserModification = user;
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        public static List<DegreeAllModel> GetDegree(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from degree in Contexto.Degrees where  degree.Status=="1" && degree.UserCreation.Equals(user)
                                 select new DegreeAllModel
                                 {
                                     Id = degree.DegreeID,
                                     Nombre = degree.Name
                                 }).ToList();
                return Resultado;
            }
        }

        public static List<DegreeAllModel> GetSubject(string user)
        {
            using (var Contexto = new appruebaEntities())
            {
                var Resultado = (from subject in Contexto.Subjects where subject.Status == "1" && subject.UserCreation.Equals(user)
                                 select new DegreeAllModel
                                 {
                                     Id = subject.SubjectsID,
                                     Nombre = subject.Name
                                 }).ToList();
                return Resultado;
            }
        }

    }
}

