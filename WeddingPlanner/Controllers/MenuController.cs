using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeddingPlanner.Controllers
{

    public class MenuController : Controller
    {
        private List<string> menuItems = new List<string>
    {
        "Chicken",
        "Steak",
        "Fish"
    };

        // GET: Menu
        public ActionResult Menu()
        {
            return View(menuItems);
        }
    }
}