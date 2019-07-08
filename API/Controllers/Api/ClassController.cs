using Business.Data.Api;
using Business.Model.Api;
using System.Web.Http;

namespace API.Controllers.Api
{
    [RoutePrefix("Api/Class")]
    public class ClassController : ApiController
    {
        [HttpPost]
        [Route("LessonWeek")]
        public IHttpActionResult Week([FromBody]TokenModel token)
        {
            bool valido = false;

            valido = TokenData.ValidarToken(token.Token);

            if (valido == true)
            {
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Week(cad);
                return Ok(consulta);
            }
                return NotFound();

            }

        [HttpPost]
        [Route("LessonDay")]
        public IHttpActionResult Days([FromBody]TokenModel token)
        {
            
            bool valido = false;
          
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Days(cad);
                return Ok(consulta);
            }
            
            return NotFound();
        }

        [HttpPost]
        [Route("LessonMonday")]
        public IHttpActionResult Monday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Lunes";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad, dia);
                return Ok(consulta);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("LessonTuesday")]
        public IHttpActionResult Tuesday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Martes";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad, dia);
                return Ok(consulta);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("LessonWednesday")]
        public IHttpActionResult Wednesday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Miercoles";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad, dia);
                return Ok(consulta);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("LessonThursday")]
        public IHttpActionResult Thursday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Jueves";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad, dia);
                return Ok(consulta);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("LessonFriday")]
        public IHttpActionResult Friday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Viernes";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad, dia);
                return Ok(consulta);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("LessonSaturday")]
        public IHttpActionResult Saturday([FromBody]TokenModel token)
        {

            bool valido = false;
            string dia = "Sabado";
            valido = TokenData.ValidarToken(token.Token);
            Comps dates = new Comps();
            if (valido == true)
            {
                //EnrollmentData Mat = new EnrollmentData();
                string cad = EnrollmentData.Enrollment(token.Token);
                var consulta = LessonWeekData.Day(cad,dia);
                return Ok(consulta);
            }

            return NotFound();
        }
    }
}
