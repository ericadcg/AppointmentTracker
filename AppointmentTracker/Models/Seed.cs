using AppointmentTracker.Data;
using AppointmentTracker.Pages.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AppointmentTracker.Models
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppointmentTrackerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppointmentTrackerContext>>()))
            {
                // Look for any movies.
                if (context.Client.Any())
                {
                    return;   // DB has been seeded
                }

                if (context.Appointment.Any())
                {
                    return;   // DB has been seeded
                }

                var clients = new Client[]
                {
                    new Client
                    {
                        FirstName = "Joao",
                        LastName = "Sousa",
                        PhoneNumber = "999666999",
                        AddressLine1 = "Rua 1",
                        AddressLine2 = "N45",
                        City= "Porto",
                        Country = "Portugal",
                        AddedDate = DateTime.Parse("2020-09-19")
                    },

                    new Client
                    {
                        FirstName = "Maria",
                        LastName = "Teixeira",
                        PhoneNumber = "999666888",
                        AddressLine1 = "Rua Sao Pdro",
                        AddressLine2 = "N55",
                        City = "Porto",
                        Country = "Portugal",
                        AddedDate = DateTime.Parse("2020-09-18")

                    },

                    new Client
                    {
                        FirstName = "Ana",
                        LastName = "Costa",
                        PhoneNumber = "999111999",
                        AddressLine1 = "Travessa de ali",
                        AddressLine2 = "N123",
                        City = "Viana do Castelo",
                        Country = "Portugal",
                        AddedDate = DateTime.Parse("2020-09-19")
                    }
                };

                context.Client.AddRange(clients);
                context.SaveChanges();

                context.Appointment.AddRange(
                    new Appointment
                    {
                        StartDate = new DateTime(2020, 10, 10, 8, 00, 00),
                        EndDate = new DateTime(2020, 10, 10, 8, 30, 00),
                        ClientId = clients.Single(c => c.FirstName == "Joao" && c.LastName == "Sousa").Id,
                        Details = "Here are some details"
                    },
                     new Appointment
                     {
                         StartDate = new DateTime(2020, 09, 20 , 9, 30, 00),
                         EndDate = new DateTime(2020, 09, 20, 10, 30, 00),
                         ClientId = clients.Single(c => c.FirstName == "Ana" && c.LastName == "Costa").Id,
                         Details = "Here are some details for this appointment"
                     }
                    );

                context.SaveChanges();
            }
        }
    }
}