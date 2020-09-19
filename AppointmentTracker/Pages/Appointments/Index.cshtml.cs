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

        public IList<Appointment> Appointment { get;set; }

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointment
                .Include(a => a.Client).ToListAsync();
        }
    }
}
