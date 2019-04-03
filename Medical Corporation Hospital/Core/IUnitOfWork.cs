using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Core.Repositories;

namespace Medical_Corporation_Hospital.Core
{
    public interface IUnitOfWork: IDisposable
    {
        IBedRepository Beds { get; }
        ICityRepository Cities { get; }
        IDoctorRepository Doctors { get; }
        IHospitalRepository Hospitals { get; }
        IPatientRepository Patients { get; }
        IWardRepository Wards { get; }

        int Complete();
    }
}