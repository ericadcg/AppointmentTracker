using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppointmentTracker.Data;
using AppointmentTracker.Models;

namespace AppointmentTracker.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly AppointmentTracker.Data.AppointmentTrackerContext _context;

        public DetailsModel(AppointmentTracker.Data.AppointmentTrackerContext context)
        {
            _context = context;
        }

        public Client Client { get; set; }
        public IList<Appointment> Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Client.FirstOrDefaultAsync(m => m.Id == id);

            if (Client == null)
            {
                return NotFound();
            }

            var auxAppointment = from a in _context.Appointment.Where(b => b.ClientId==id) select a;

            Appointment = await auxAppointment
                .Include(c => c.Client).ToListAsync(); 

            return Page();
        }

       
    }
}
