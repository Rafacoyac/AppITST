using API.Models;
using API.Providers;
using Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("Api/Lesson")]
    public class LessonsController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]LessonModel lessons)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.Crear(lessons.Dia, lessons.EmpleadosId, lessons.HoraIn, lessons.HoraFin, lessons.AulaId, lessons.MateriaId,u);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.Mostrar(u);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowUpdate(LessonModel lesson)
        {
            var consulta = LessonData.MostrarActualizar(lesson.LessonId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Day")]
        public IHttpActionResult Day(LessonModel lesson)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.GetDia(lesson.Dia,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(LessonModel lesson)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.Actualizar(lesson.LessonId, lesson.Dia, lesson.EmpleadosId, lesson.HoraIn, lesson.HoraFin, lesson.AulaId, lesson.MateriaId,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(LessonModel lesson)
        {
            var consulta = LessonData.Eliminar(lesson.LessonId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowEmployer")]
        public IHttpActionResult GetEmployer()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.ObtenerEmpleado(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowClassroom")]
        public IHttpActionResult GetAula()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.ObtenerAula(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowSubject")]
        public IHttpActionResult GetMateria()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.ObtenerMateria(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowGroup")]
        public IHttpActionResult GetGrupo()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = LessonData.ObtenerGrupo(u);
            return Ok(consulta);
        }
        
    }
}
