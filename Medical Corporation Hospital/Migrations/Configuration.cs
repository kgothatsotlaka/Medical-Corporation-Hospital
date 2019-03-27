using System.Collections.Generic;
using Medical_Corporation_Hospital.Models;

namespace Medical_Corporation_Hospital.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Medical_Corporation_Hospital.Models.HospitalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Medical_Corporation_Hospital.Models.HospitalDbContext context)
        {/*
            #region Add Cities

            var cities = new Dictionary<string, City>
            {

                {"Pretoria", new City {Id = 1, Name = "Pretoria", Province = "Gauteng", Country = "South Africa"}},
                {
                    "Johannesburg",
                    new City {Id = 2, Name = "Johannesburg", Province = "Gauteng", Country = "South Africa"}
                },
                {"Cape Town", new City {Id = 2, Name = "Johannesburg", Province = "Gauteng", Country = "South Africa"}}
            };


            foreach (var city in cities.Values)
            {
                context.Cities.AddOrUpdate(c => c.Id, city);
            }

            #endregion

            #region Add Beds

            var beds = new Dictionary<int, Bed>
            {
                {1, new Bed{Id = 1, Number = 1, Occupied = "No"}},
                {2, new Bed{Id = 2, Number = 2, Occupied = "No"}},
                {3, new Bed{Id = 3, Number = 3, Occupied = "No"}},
                {4, new Bed{Id = 4, Number = 4, Occupied = "No"}},
                {5, new Bed{Id = 5, Number = 5, Occupied = "No"}},
                {6, new Bed{Id = 6, Number = 6, Occupied = "No"}},
                {7, new Bed{Id = 7, Number = 7, Occupied = "No"}},
                {8, new Bed{Id = 8, Number = 8, Occupied = "No"}},

            };

            foreach (var bed in beds)
            {
                context.Beds.AddOrUpdate(b=>b.Id);
            }




            #endregion

            #region Ward

            

            #endregion
            */
        }
    }
}
