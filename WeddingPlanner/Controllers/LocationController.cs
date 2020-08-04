using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeddingPlanner.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Map()
        {
            return View();
        }
    }
}