using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace AppointmentTracker.Models
{
    public class EmailHandler : SmtpClient
    {
        //TODO: Move email configuration to appsettings
        public EmailHandler() : base()
        {
            var credential = new NetworkCredential()
            {
                UserName = "edc.gomes9@gmail.com",  // mail 
                Password = "doqmvyctltcvkbmv"  // app password
            };

            this.Credentials = credential;
            this.Host = "smtp.gmail.com"; //gmail smtp
            this.Port = 587;
            this.EnableSsl = true;
        }
        
        //Creates email details for the given appointment 
        public MailMessage CreateAppointmentEmail(Appointment appointment) 
        {
            MailMessage message = new MailMessage();
            message.To.Add(appointment.Client.Email);
            message.Subject = "New Appointment";
            message.Body = $"<p>Dear {appointment.Client.FullName},</p> <p>Your next appointment is scheduled on {appointment.StartDate}.</p>";
            message.IsBodyHtml = true;
            message.From = new MailAddress("edc.gomes9@gmail.com");

            return message;
        }
    }
}
