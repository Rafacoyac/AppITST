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
    [RoutePrefix("Api/Subject")]
    public class SubjectController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]SubjectModel subject)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = SubjectData.Crear(subject.Clave, subject.Nombre, subject.Creditos, subject.CarreraId, subject.EspecialidadId,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = SubjectData.Mostrar(u);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowUpdate(SubjectModel subject)
        {
            var consulta = SubjectData.MostrarActualizar(subject.SubjectId);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(SubjectModel subject)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = SubjectData.Actualizar(subject.SubjectId, subject.Clave, subject.Nombre, subject.Creditos, subject.CarreraId, subject.EspecialidadId,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(SubjectModel subject)
        {
            var consulta = SubjectData.Eliminar(subject.SubjectId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowCareer")]
        public IHttpActionResult ShowCareer()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = SubjectData.ObtenerCarrera(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowSpeciality")]
        public IHttpActionResult Showspeciality()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = SubjectData.ObtenerEspecialidad(u);
            return Ok(consulta);
        }

    }
}
