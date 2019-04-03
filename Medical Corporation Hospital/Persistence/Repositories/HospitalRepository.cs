﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Core.Repositories;
using Medical_Corporation_Hospital.Models;

namespace Medical_Corporation_Hospital.Persistence.Repositories
{
    public class HospitalRepository:Repository<Hospital>, IHospitalRepository
    {
        public HospitalRepository(HospitalDbContext context):base(context)
        {
            
        }
        public HospitalDbContext HospitalDbContext
        {
            get { return Context as HospitalDbContext; }
        }
    }
}