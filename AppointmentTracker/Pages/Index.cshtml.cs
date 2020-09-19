using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AppointmentTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentTracker.Pages
{
    public class IndexModel : PageModel
    {
        /*private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        { _logger = logger;}
        public void OnGet()
        { }*/


        private readonly AppointmentTracker.Data.AppointmentTrackerContext _context;

        public IndexModel(AppointmentTracker.Data.AppointmentTrackerContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime SelectedDate { get; set; }
      


        public async Task OnGetAsync()
        {
            if (SelectedDate == DateTime.MinValue)
            {
                SelectedDate = DateTime.Now.AddDays(14);
            }
            var AppointmentAux = from a in _context.Appointment.Where( b => b.StartDate > DateTime.Now && b.StartDate <= SelectedDate) select a;

            Appointment = await AppointmentAux
                  .Include(a => a.Client).ToListAsync();
        }
    }
}
