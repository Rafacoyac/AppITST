using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApptecPortalWeb.Controllers
{
    public class InstitutionsController : Controller
    {
        // GET: Institutions
        public ActionResult CreateInstitution()
        {
            return View();
        }

        public ActionResult ShowInstitution()
        {
            return View();
        }
    }
}