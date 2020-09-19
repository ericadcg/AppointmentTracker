using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppointmentTracker.Models;

namespace AppointmentTracker.Data
{
    public class AppointmentTrackerContext : DbContext
    {
        public AppointmentTrackerContext (DbContextOptions<AppointmentTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<AppointmentTracker.Models.Client> Client { get; set; }

        public DbSet<AppointmentTracker.Models.Appointment> Appointment { get; set; }
    }
}
