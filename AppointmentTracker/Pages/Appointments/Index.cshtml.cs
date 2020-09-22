using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppointmentTracker.Data;
using AppointmentTracker.Models;

namespace AppointmentTracker.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly AppointmentTracker.Data.AppointmentTrackerContext _context;

        public IndexModel(AppointmentTracker.Data.AppointmentTrackerContext context)
        {
            _context = context;
        }

        public IList<Appointment> FutureAppointment { get;set; }

        public IList<Appointment> PastAppointment { get; set; }

        public async Task OnGetAsync()
        {
           
            //Gets future appointments
            var AuxAppointments = from a in _context.Appointment.Where(b => DateTime.Compare(b.StartDate, DateTime.Now) > 0) select a;

            FutureAppointment = await AuxAppointments
                .Include(a => a.Client).ToListAsync();

            FutureAppointment.OrderBy(a => a.StartDate);

            //Gets past appointments
            var AuxAppointment2 = from a in _context.Appointment.Where(b => DateTime.Compare(b.StartDate, DateTime.Now) < 0 ) select a;
                               
            PastAppointment = await AuxAppointment2
                .Include(c => c.Client).ToListAsync();

            PastAppointment.OrderByDescending(a => a.StartDate);           
        }
    }
}
