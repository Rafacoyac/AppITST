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
    [RoutePrefix("Api/DegreeSubject")]
    public class DegreeSubjectController : ApiController
    {

        Credenciales credenciales = new Credenciales();
        public string u;

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]DegreeSubjectModel degreeSubject)
        {

            u = credenciales.getUsuario();
            var consulta = DegreeSubjectData.Crear(degreeSubject.DegreeId, degreeSubject.SubjectId,u);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            var consulta = DegreeSubjectData.Mostrar(u);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowUpdate(DegreeSubjectModel degreeSubject)
        {
            var consulta = DegreeSubjectData.MostrarActualizar(degreeSubject.DegreeSubjectId);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(DegreeSubjectModel degreeSubject)
        {
            u = credenciales.getUsuario();
            var consulta = DegreeSubjectData.Actualizar(degreeSubject.DegreeSubjectId, degreeSubject.DegreeId, degreeSubject.SubjectId,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("GetDegree")]
        public IHttpActionResult GetDegree()
        {
            u = credenciales.getUsuario();
            var consulta = DegreeSubjectData.GetDegree(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("GetSubject")]
        public IHttpActionResult GetSubject()
        {
            u = credenciales.getUsuario();
            var consulta = DegreeSubjectData.GetSubject(u);
            return Ok(consulta);
        }

    }
}
