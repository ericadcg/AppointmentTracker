using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppointmentTracker.Data;
using AppointmentTracker.Models;

namespace AppointmentTracker.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly AppointmentTracker.Data.AppointmentTrackerContext _context;

        public CreateModel(AppointmentTracker.Data.AppointmentTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientId"] = new SelectList(_context.Client, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
