using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppointmentTracker.Data;
using AppointmentTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppointmentTracker.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly AppointmentTracker.Data.AppointmentTrackerContext _context;

        public IndexModel(AppointmentTracker.Data.AppointmentTrackerContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        public SelectList City { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedCity { get; set; }
        //To be implemented dropdown with cities

        public async Task OnGetAsync()
        {

            // Use LINQ to get list of all cities in client's table
            IQueryable<string> cityQuery = from c in _context.Client
                                    orderby c.City
                                    select c.City;

            // Use LINQ to get list of all clients
            var clients = from c in _context.Client
                         select c;

            if (!string.IsNullOrEmpty(SearchString))
            {
                //Checks if search string is in the firstName or in the last name
                clients = clients.Where(s => s.FirstName.Contains(SearchString) || s.LastName.Contains(SearchString) || SearchString==s.FirstName+" "+s.LastName);
            }

            if (!string.IsNullOrEmpty(SelectedCity))
            {
                //Gets clients with same city as the selected city
                clients = clients.Where(x => x.City == SelectedCity);
            }
            //List of cities is created by getting all different cities in DB
            City = new SelectList(await cityQuery.Distinct().ToListAsync());

            Client = await clients.ToListAsync();                 
            
        }
    }
}
