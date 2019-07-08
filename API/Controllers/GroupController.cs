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
    [RoutePrefix("Api/Group")]
    public class GroupController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;


        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]GroupModel group)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();

            var consulta = GroupData.Crear(group.Nombre,u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();

            var consulta = GroupData.Mostrar(u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowUpdate([FromBody]GroupModel group)
        {
            var consulta = GroupData.MostrarUpdate(group.GroupId);

            return Ok(consulta);
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update([FromBody]GroupModel group)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = GroupData.Actualizar(group.GroupId, group.Nombre,u);

            return Ok(consulta);
        }


        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(GroupModel group)
        {
            var consulta = GroupData.Eliminar(group.GroupId);
            return Ok(consulta);
        }

    }
}
