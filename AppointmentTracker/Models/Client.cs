using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppointmentTracker.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="{0} is mandatory")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} is mandatory")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        [Display(Name = "Client Since")]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        public string Email { get; set; }

        [Display(Name = "Name")]
        public string FullName { get => FirstName + " " + LastName; }

        [Display(Name = "Address")]
        public string FullAddress { get => AddressLine1 + " " + AddressLine2 + ", " + City + ", " + Country; }


    }
}
