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
    [RoutePrefix("Api/Degree")]
    public class DegreeController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]DegreeModel degree)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = DegreeData.Crear(degree.Nombre,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowUpdate([FromBody]DegreeModel degree)
        {
            var consulta = DegreeData.MostrarUpdate(degree.DegreeId);
          
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update([FromBody]DegreeModel degree)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = DegreeData.Actualizar(degree.DegreeId, degree.Nombre,u);

            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = DegreeData.Mostrar(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(DegreeModel degree)
        {
            var consulta = DegreeData.Eliminar(degree.DegreeId);
            return Ok(consulta);
        }
    }
}
