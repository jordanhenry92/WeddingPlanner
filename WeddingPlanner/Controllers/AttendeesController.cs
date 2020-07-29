using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class AttendeesController : Controller
    {
        private ApplicationDbContext _context;

        public AttendeesController()
        {
            _context = new ApplicationDbContext();
        }

        // Override base dispose method for our DbContext
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Attendees
        public ActionResult Index()
        {
            var attendees = _context.Attendees
                .Include(a => a.Role)
                .ToList();

            return View(attendees);
        }
    }
}