
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NBD_ClientManagementGood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBD_ClientManagementGood.Data
{
    public static class CMOSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new NBD_ClientManagementGoodContext(
                serviceProvider.GetRequiredService<DbContextOptions<NBD_ClientManagementGoodContext>>()))
            {
                //Countries
                if (!context.Countries.Any())
                {
                    context.Countries.AddRange(
                        new Country
                        {
                            Name = "Canada"
                        },
                        new Country
                        {
                            Name = "United States"
                        },
                        new Country
                        {
                            Name = "Mexico"
                        });
                    context.SaveChanges();
                }

                //Cities
                if (!context.Cities.Any())
                {
                    context.Cities.AddRange(
                        new City
                        {
                            Name = "Toronto",
                            State = "Ontario",
                            CountryID = context.Countries.FirstOrDefault(p => p.Name == "Canada").CountryID
                        },
                        new City
                        {
                            Name = "Vancouver",
                            State = "British Columbia",
                            CountryID = context.Countries.FirstOrDefault(p => p.Name == "Canada").CountryID

                        },
                        new City
                        {
                            Name = "Montreal",
                            State = "Qubec",
                            CountryID = context.Countries.FirstOrDefault(p => p.Name == "Canada").CountryID
                        });
                    context.SaveChanges();
                }

                // Look for any Bids.  Since we can't have Bids without Projects.
                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(
                     new Project
                     {

                         Name = "Great Wolf Lodge",
                         StartDate = DateTime.Parse("2019 - 03 -17"),
                         EndDate = DateTime.Parse("2019 - 05 - 17"),
                         ClientID = context.Clients.FirstOrDefault(c => c.FirstName == "Cisco" && c.LastName == "Ramon").ClientID
                     },
                     new Project
                     {
                         Name = "Niagara College",
                         StartDate = DateTime.Parse("2019 - 06 -04"),
                         EndDate = DateTime.Parse("2019 - 09 - 17"),
                         ClientID = context.Clients.FirstOrDefault(c => c.FirstName == "Joe" && c.LastName == "West").ClientID
                     },
                     new Project
                     {
                         Name = "Canadian Tire",
                         StartDate = DateTime.Parse("2019 - 10 -01"),
                         EndDate = DateTime.Parse("2020 - 01 - 01"),
                         ClientID = context.Clients.FirstOrDefault(c => c.FirstName == "Barry" && c.LastName == "Allen").ClientID
                     });
                    context.SaveChanges();
                }

                //Clients
                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(
                    //new Client
                    //{
                    //    FirstName = "Barry",
                    //    MiddleName = "Thawn",
                    //    LastName = "Allen",
                    //    Address = "65 Centre st",
                    //    eMail = "fflintstone@outlook.com",
                    //    PostalCode = "L4Z6Y2",
                    //    Phone = 9055551212,
                    //    //Position = "Manager",
                    //    CityID = context.Cities.FirstOrDefault(p => p.Name == "Toronto").CityID
                    //},
                    //new Client
                    //{
                    //    FirstName = "Cisco",
                    //    MiddleName = "Thawn",
                    //    LastName = "Ramon",
                    //    Address = "92 Lake st",
                    //    eMail = "fflintstone@outlook.com",
                    //    PostalCode = "L4Z6Y2",
                    //    Phone = 9055551212,
                    //    //Position = "Manager",
                    //    CityID = context.Cities.FirstOrDefault(p => p.Name == "Vancouver").CityID
                    //},
                    //new Client
                    //{
                    //    FirstName = "Joe",
                    //    MiddleName = "Jacobs",
                    //    LastName = "West",
                    //    Address = "Reginald",
                    //    eMail = "fflintstone@outlook.com",
                    //    PostalCode = "L4Z6Y2",
                    //    Phone = 9055551212,
                    //    //Position = "Manager",
                    //    CityID = context.Cities.FirstOrDefault(p => p.Name == "Toronto").CityID
                    //},
                    new Client
                    {
                        FirstName = "Eobard",
                        MiddleName = "Thawn",
                        LastName = "Maker",
                        Address = "6 Skywalk ln",
                        eMail = "fflintstone@outlook.com",
                        PostalCode = "L4Z6Y2",
                        Phone = 9055551212,
                        CityID = context.Cities.FirstOrDefault(p => p.Name == "Montreal" && p.State == "Qubec").CityID
                    });
                    context.SaveChanges();
                }           
            }
        }
    }
}
