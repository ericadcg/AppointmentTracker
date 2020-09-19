using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentTracker.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public string Details { get; set; }

        
    }
}
