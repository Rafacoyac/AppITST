using API.Models;
using Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Providers;


namespace API.Controllers
{
    [RoutePrefix("Api/Career")]
    public class CareerController : ApiController
    {

        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;

        
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]CareerModel career)
        {

            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = CareerData.Crear(career.Clave, career.Nombre, career.InstitucionId,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = CareerData.Mostrar(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowUpdate(CareerModel career)
        {
     
            var consulta = CareerData.MostrarActualizar(career.CareerId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(CareerModel career)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = CareerData.Actualizar(career.CareerId, career.Clave, career.Nombre, career.InstitucionId, u);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(CareerModel career)
        {
            var consulta = CareerData.Eliminar(career.CareerId);
            return Ok(consulta);
        }
    }
}
