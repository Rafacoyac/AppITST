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
    [RoutePrefix("Api/Classroom")]
    public class ClassroomController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;


        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]ClassroomModel classroom)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = ClassroomData.Crear(classroom.Clave,classroom.Nombre,classroom.Descripcion,classroom.Institucion,classroom.TipoAula,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();

            var consulta = ClassroomData.Mostrar(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowUpdate(ClassroomModel classroom)
        {
            var consulta = ClassroomData.MostrarUpdate(classroom.ClassroomId);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(ClassroomModel classroom)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = ClassroomData.Atualizar(classroom.ClassroomId, classroom.Clave, classroom.Nombre, classroom.Descripcion, classroom.Institucion, classroom.TipoAula,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(ClassroomModel classroom)
        {
            var consulta = ClassroomData.Eliminar(classroom.ClassroomId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowClassroomType")]
        public IHttpActionResult ShowClassroomType()
        {
            var consulta = ClassroomData.ObtenerAula();
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowInstitution")]
        public IHttpActionResult ShowInstitution()
        {
            u = credenciales.getUsuario();
            var consulta = ClassroomData.ObtenerInstitucion(u);
            return Ok(consulta);
        }
    }
}
