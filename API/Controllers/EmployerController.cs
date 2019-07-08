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
    [RoutePrefix("Api/Employer")]
    public class EmployerController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;


        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]EmployerModel employer)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = EmployerData.Crear(employer.Nombre, employer.Apellidop, employer.Apellidom, employer.Rfc, employer.RolesId, employer.InstitucionId,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = EmployerData.Mostrar(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowActualizar(EmployerModel employer)
        {
            var consulta = EmployerData.MostrarActualizar(employer.EmployerId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(EmployerModel employer)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = EmployerData.Actualizar(employer.EmployerId, employer.Nombre, employer.Apellidop, employer.Apellidom, employer.Rfc, employer.RolesId, employer.InstitucionId,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(EmployerModel employer)
        {
            var consulta = EmployerData.Eliminar(employer.EmployerId);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowRol")]
        public IHttpActionResult ShowRol()
        {
            var consulta = EmployerData.ObtenerRol();
            return Ok(consulta);
        }
        
    }
}

