using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Data;
using Data;
using API.Providers;
using API.Models;

namespace API.Controllers
{



    [RoutePrefix("Api/Institution")]
    public class InstitutionController : ApiController
    {
        Credenciales credenciales = new Credenciales();

        string u;

        [HttpPost]
        [Route("ShowEducationLevel")]
        public IHttpActionResult ShowEducationLevel()
        {
            var consulta = InstitutionData.ObtenerNivel();
            return Ok(consulta);
        }


        [HttpPost]
        [Route("SHow")]
        public IHttpActionResult Show()
        {

            u = credenciales.getUsuario();
            var consulta = InstitutionData.Mostrar(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]InstitutionsRegisterModel inst)
        {
            u = credenciales.getUsuario();
            var consulta = InstitutionData.Crear(inst.Name, inst.Direction, inst.Phone, inst.EducationLevelID, inst.Director, u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("UpdateSHow")]
        public IHttpActionResult UpdateShow([FromBody] InstitutionsRegisterModel inst)
        {
            var consulta = InstitutionData.UpdateShow(inst.InstitutionID);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("UpdateRegister")]
        public IHttpActionResult UpdateRegister([FromBody] InstitutionsRegisterModel inst)
        {
            u = credenciales.getUsuario();
            var consulta = InstitutionData.UpdateRegister(inst.InstitutionID, inst.Name, inst.Direction, inst.Phone, inst.EducationLevelID, inst.Logo, inst.Director, u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("UpdateRegisterUser")]
        public IHttpActionResult UpdateRegisterUser([FromBody] InstitutionsRegisterModel inst)
        {
            u = credenciales.getUsuario();
            var consulta = InstitutionData.UpdateRegisterUser(inst.InstitutionID, inst.UserCreation);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete([FromBody]InstitutionsRegisterModel inst)
        {
            var consulta = InstitutionData.Eliminar(inst.InstitutionID);
            return Ok(consulta);
        }

    }
}
