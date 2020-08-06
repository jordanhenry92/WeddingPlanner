using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WeddingPlanner.Models;
using WeddingPlanner.ViewModels;
using System.Web.Configuration;

namespace WeddingPlanner.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendeesController()
        {
            _context = new ApplicationDbContext();
        }

        // Override base dispose method for our DbContext
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Returns a list of attendees in the db
        public ActionResult Index()
        {
            var attendees = _context.Attendees
                .Include(a => a.Role)
                .ToList();

            return View(attendees);
        }

        // Returns a form that allows a user to edit an attendee's details
        public ActionResult Edit(int id)
        {
            var attendee = _context.Attendees.SingleOrDefault(a => a.Id == id);

            if (attendee == null)
                return HttpNotFound();

            var viewModel = new AttendeeFormViewModel
            {
                Attendee = attendee,
                Roles = _context.Roles.ToList()
            };

            return View("AttendeeForm", viewModel);
        }

        // Saves an edited attendee to the database and returns user to attendees list
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Attendee attendee)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AttendeeFormViewModel
                {
                    Attendee = attendee,
                    Roles = _context.Roles
                };

                return View("AttendeeForm", viewModel);
            }

            if (attendee.Id == 0)
                _context.Attendees.Add(attendee);
            else
            {
                var attendeeInDb = _context.Attendees.SingleOrDefault(a => a.Id == attendee.Id);

                attendeeInDb.FirstName = attendee.FirstName;
                attendeeInDb.LastName = attendee.LastName;
                attendeeInDb.Email = attendee.Email;
                attendeeInDb.PhoneNumber = attendee.PhoneNumber;
                attendeeInDb.RoleId = attendee.RoleId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Attendees");
        }

        // Returns a view of an uninstantiated customer
        public ActionResult New()
        {
            var roles = _context.Roles.ToList();
            var viewModel = new AttendeeFormViewModel
            {
                Attendee = new Attendee(),
                Roles = roles
            };

            return View("AttendeeForm", viewModel);
        }

        // Deletes the specified attendee from the db
        // TODO add a confirmation box for the user and fix button styling so its justified right
        public ActionResult Delete(int id)
        {
            var attendee = _context.Attendees.SingleOrDefault(a => a.Id == id);

            if (attendee == null)
                return HttpNotFound();

            _context.Attendees.Remove(attendee);
            _context.SaveChanges();

            return RedirectToAction("Index", "Attendees");
        }
    }
}