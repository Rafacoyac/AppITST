using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Data;
using API.Models;
using API.Providers;

namespace API.Controllers
{
    [RoutePrefix("Api/Binnacle")]
    public class BinnacleController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;


        [HttpPost]
        [Route("Info")]
        public IHttpActionResult Create([FromBody]BinnacleModel binnacle)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();

            var consulta = BinnacleData.Recibir(binnacle.Accion, binnacle.Error, binnacle.Msj, u);
            return Ok(consulta);
        }

    }
}
