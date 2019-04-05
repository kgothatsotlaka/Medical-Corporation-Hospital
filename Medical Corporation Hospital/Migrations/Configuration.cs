using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using Medical_Corporation_Hospital.Core.Domain;
using Medical_Corporation_Hospital.Persistence;
using Newtonsoft.Json.Linq;

namespace Medical_Corporation_Hospital.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<HospitalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HospitalDbContext context)
        {
           

            #region Add Doctor

            var doctors = new Dictionary<string, Doctor>
            {
                {"Ledwaba",new Doctor
                {
                    Id = 1,
                    Initials = "L M",
                    LastName = "Ledwaba",
                    Address = "Address 1",
                    Telephone = "0125555"
                } } ,


                {"Mashifane", new Doctor
                {
                    Id = 2,
                    Initials = "S D",
                    LastName = "Mashifane",
                    Address = "Address 2",
                    Telephone = "012 55"
                }}
                    ,

                    {"Mampuru",  new Doctor
                    {
                        Id = 3,
                        Initials = "R M",
                        LastName = "Mampuru",
                        Address = "Address 3",
                        Telephone = "012555"
                    }}
                   
                
            };
            foreach (var doctor in doctors)
            {
                context.Doctors.AddOrUpdate(d => d.Id, doctor.Value);
            }

            #endregion



            //New Attempt: The only way to eat an elephant
            #region Add Cities

            var cities = new List<City>
            {
                new City
                {
                    Id = 1,
                    Name = "Pretoria",
                    Province = "Gauteng",
                    Country = "South Africa"
                }
            };
            foreach (var city in cities) context.Cities.AddOrUpdate(c => c.Id, city);

            #endregion

            #region Add hospitals

            var hospitals = new List<Hospital>
            {
                //Pretoria
                new Hospital
                {
                    Id = 1,
                    Name = "Mediclinic Muelmed",
                     CityId = 1,
                     Doctors = new Collection<Doctor>()
                     {
                        doctors["Mampuru"],
                        doctors["Ledwaba"]
                     }
                },
                new Hospital
                {
                    Id = 2,
                    Name = "Netcare Femina Hospital",
                     CityId = 1,
                     Doctors = new Collection<Doctor>()
                     {
                         doctors["Mampuru"],
                         doctors["Mashifane"]
                     }
                },
                new Hospital
                {
                    Id = 3,
                    Name = "Louis Pasteur Private Hospital",
                       CityId = 1,
                       Doctors = new Collection<Doctor>()
                       {
                           
                           doctors["Mashifane"]
                       }
                }
            };
            foreach (var hospital in hospitals)
            {
                context.Hospitals.AddOrUpdate(h=>h.Id,hospital);
            }

            #endregion

            #region Add Wards

            var wards = new List<Ward>
            {
                new Ward
                {
                    Id = 1,
                    Name = "MM1",
                    HospitalId = 1
                },
                new Ward
                {
                    Id = 2,
                    Name = "MM3",
                    HospitalId = 1
                },
                new Ward
                {
                    Id = 3,
                    Name = "MM3",
                    HospitalId = 1
                }
            };

            foreach (var ward in wards)
            {
                context.Wards.AddOrUpdate(w=>w.Id,ward);
            }

            #endregion

            #region Add Beds

            var beds = new List<Bed>
            {

                new Bed
                {
                    Id = 1,
                    Number = 1,
                    Occupied = "No",
                    wardId = 1
                },


                new Bed
                {
                    Id = 2,
                    Number = 2,
                    Occupied = "Yes",
                    wardId = 1

                },
                new Bed
                {
                    Id = 3,
                    Number = 3,
                    Occupied = "Yes",
                    wardId = 2

                },
                new Bed
                {
                    Id = 4,
                    Number = 4,
                    Occupied = "Yes",
                    wardId = 2

                }



            };

            foreach (var bed in beds) context.Beds.AddOrUpdate(b => b.Id, bed);

            #endregion

            #region Add Patients

            var patients = new List<Patient>
            {
                new Patient
                {
                    Id=1,
                    FullName = "Jacob Zuma",
                    AdmissionTime = DateTime.Today,
                    Address = "Patient 1 Address",
                    Telephone = "0123456789",
                    HospitalId = 1,
                    WardId = 1,
                    


                    Doctors = new Collection<Doctor>()
                    {
                       doctors["Ledwaba"]
           
                    }

                }
            };

            foreach (var patient in patients)
            {
                context.Patients.AddOrUpdate(p=>p.Id, patient);
            }

            #endregion


           








        }
    }
}