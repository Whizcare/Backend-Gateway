using System;
using DataEntities.Entities;

namespace DataEntities
{
    public class Presciptions : IPrescriptions
    {
        private readonly ProjectDatabaseContext context;
        public Presciptions(ProjectDatabaseContext _conext)
        {
            context = _conext;
        }

        public Prescription AddPrescription(Prescription prescription)
        {

            context.Prescriptions.Add(prescription);
            context.SaveChanges();
            return prescription;
        }

        public List<Prescription> GetPrescription(Guid hhid)
        {
            var s=(from prescription in context.Prescriptions
                   where prescription.HhId== hhid
                   select prescription).ToList();
            return s;
        }
    }
     
   
}

