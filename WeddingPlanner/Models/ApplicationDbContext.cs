﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeddingPlanner.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}