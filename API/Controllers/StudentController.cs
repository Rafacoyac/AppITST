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
    [RoutePrefix("Api/Student")]
    public class StudentController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;

        
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]StudentModel student)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = StudentData.Crear(student.Matricula, student.Nombre, student.Apellidop, student.Apellidom, student.Telefono, student.InstitucionId, student.GrupoId, student.Grado, u);
            return Ok(consulta);
        }

       
        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = StudentData.Mostrar(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowUpdate(StudentModel student)
        {
            var consulta = StudentData.MostrarActualizar(student.StudentId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(StudentModel student)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = StudentData.Actualizar(student.StudentId, student.Matricula, student.Nombre, student.Apellidop, student.Apellidom, student.Telefono, student.InstitucionId, student.GrupoId, student.Grado,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(StudentModel student)
        {
            var consulta = StudentData.Eliminar(student.StudentId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowGroup")]
        public IHttpActionResult ShowGroup()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = StudentData.ObtenerGroup(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowDegree")]
        public IHttpActionResult ShowDegree()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = StudentData.ObtenerGrado(u);
            return Ok(consulta);
        }
    }
}
