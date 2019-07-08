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
    [RoutePrefix("Api/Speciality")]
    public class SpecialityController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]SpecialityModel speciality)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = SpecialityData.Crear(speciality.Nombre, speciality.InstitucionId,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();

            var consulta = SpecialityData.Mostrar(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowActualizar(SpecialityModel speciality)
        {
            var consulta = SpecialityData.MostrarUpdate(speciality.SpecialityId);
            return Ok(consulta);
        }
        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(SpecialityModel speciality)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();

            var consulta = SpecialityData.Actualizar(speciality.SpecialityId, speciality.Nombre, speciality.InstitucionId,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(SpecialityModel speciality)
        {
            var consulta = SpecialityData.Eliminar(speciality.SpecialityId);
            return Ok(consulta);
        }
    }
}
