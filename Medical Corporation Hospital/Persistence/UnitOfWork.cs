using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Core;
using Medical_Corporation_Hospital.Core.Repositories;
using Medical_Corporation_Hospital.Models;
using Medical_Corporation_Hospital.Persistence.Repositories;

namespace Medical_Corporation_Hospital.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly HospitalDbContext _context;

        public UnitOfWork(HospitalDbContext context)
        {
            _context = context;
            Beds = new BedRepository(_context);
            Cities = new CityRepository(_context);
            Hospitals = new HospitalRepository(_context);
            Doctors = new DoctorRepository(_context);
            Patients = new PatientRepository(_context);
            Wards = new WardRepository(_context);

        }
        public IBedRepository Beds { get; private set; }
        public ICityRepository Cities { get; private set; }
        public IHospitalRepository Hospitals { get; private set; }
        public IDoctorRepository Doctors { get; private set; }
        public IPatientRepository Patients { get; private set; }
        public IWardRepository Wards { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            ;
        }
    }
}