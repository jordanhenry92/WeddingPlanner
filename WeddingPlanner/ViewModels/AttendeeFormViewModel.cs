using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingPlanner.Models;

namespace WeddingPlanner.ViewModels
{
    public class AttendeeFormViewModel
    {
        public Attendee Attendee { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}