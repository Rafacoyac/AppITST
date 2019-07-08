using API.Models;
using Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Microsoft.AspNet.Identity;

namespace API.Controllers
{
    [RoutePrefix("Api/Login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Authenticate")]
        public IHttpActionResult Sign([FromBody]UserModel user)
        {
            Boolean Existe = false;


            Existe = UserData.ExisteUsuario(user.User, user.Password);
            if (Existe == true)
            {
                //token falta
                user.User = User.Identity.GetUserId();

                
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Logout")]
        public IHttpActionResult Out([FromBody]UserModel user)
        {
            //Invalidar token
            return BadRequest();
        }

        
    }
}
