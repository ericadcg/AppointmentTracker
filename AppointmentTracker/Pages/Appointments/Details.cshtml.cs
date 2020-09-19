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
    public class DetailsModel : PageModel
    {
        private readonly AppointmentTracker.Data.AppointmentTrackerContext _context;

        public DetailsModel(AppointmentTracker.Data.AppointmentTrackerContext context)
        {
            _context = context;
        }

        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment = await _context.Appointment
                .Include(a => a.Client).FirstOrDefaultAsync(m => m.Id == id);

            if (Appointment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
