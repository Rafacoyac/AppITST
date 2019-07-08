using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApptecPortalWeb.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult CreateProfile()
        {
            return View();
        }

        public ActionResult ShowProfile()
        {
            return View();
        }
    }
}