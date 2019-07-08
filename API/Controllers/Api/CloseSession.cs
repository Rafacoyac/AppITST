using Business.Data.Api;
using Business.Model.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers.Api
{
    [RoutePrefix("Api/Class")]
    public class CloseSession:ApiController
    {
        [HttpPost]
        [Route("cerrar")]
        public IHttpActionResult Cerrar(TokenModel token)
        {

            TokenData.InvalidarToken(token.Token);

            return BadRequest();
        }
    }
}