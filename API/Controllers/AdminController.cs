using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using Business.Data;
using API.Providers;
using Data;
using System.IO;
using System.Media;
using System.Web;

namespace API.Controllers
{
    [RoutePrefix("Api/Admin")]
    public class AdminController : ApiController
    {

        Credenciales credenciales = new Credenciales();
        string u;
        string c;
        string imagen;

        [HttpPost]
        [Route("file")]
        public string PosteandoMostrar()
        {
            byte[] buffer;
            var request = HttpContext.Current.Request;
            if (request.Files.Count > 0)
            {
                foreach (string file in request.Files)
                {
                    var postedFile = request.Files[file];
                    int length = postedFile.ContentLength;
                    buffer = new byte[length];
                    postedFile.InputStream.Read(buffer, 0, length);
                    imagen = Convert.ToBase64String(buffer);

                    ImagenModel imagenModel = new ImagenModel(imagen);

                    return imagen;
                }
            }
            return "";
        }


        [HttpPost]
        [Route("Create")]

        public IHttpActionResult Create([FromBody]AdminModel admin)
        {
            u = credenciales.getUsuario();
            c = credenciales.getContra();



            ImagenModel imagenModel = new ImagenModel();
            var nose = imagenModel.getIamge();



            var consulta = AdminData.Crear(admin.Name, admin.LastNameP, admin.LastNameM, admin.Users, admin.Pass, admin.InstitutionID, nose);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            var consulta = AdminData.Mostrar(u);
            return Ok(consulta);
        }


        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(AdminModel admin)
        {
            var consulta = AdminData.Eliminar(admin.AdminsID);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("UpdateShow")]
        public IHttpActionResult UpdateShow([FromBody]AdminModel admin)
        {
            var consulta = AdminData.UpdateShow(admin.Users, admin.Pass);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("UpdateRegister")]
        public IHttpActionResult UpdateRegister([FromBody]AdminModel admin)
        {


            ImagenModel imagenModel = new ImagenModel();
            var nose = imagenModel.getIamge();

            u = credenciales.getUsuario();
            var consulta = AdminData.UpdateRegister(admin.Name, admin.LastNameP, admin.LastNameM, admin.Users, admin.Pass, admin.InstitutionID, nose, u);
            return Ok(consulta);
        }

        [HttpPost]
        [Route("ShowInstitutions")]
        public IHttpActionResult ShowInstitutions()
        {
            var consulta = AdminData.ObtenerInstitution();
            return Ok(consulta);
        }


    }
}
