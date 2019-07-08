using Business.Data.Api;
using Business.Model.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers.Api
{
    [RoutePrefix("Api/Perfil")]
    public class PerfilController : ApiController
    {

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show([FromBody]TokenModel token)
        {
            bool valido = false;

            valido = TokenData.ValidarToken(token.Token);

            if (valido == true)
            {
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = PerfilData.Mostrar(cad);
            return Ok(consulta);
            }
            return NotFound();
            
        }
    }
}