
using DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class PatientRepo:IPatient
    {
        private readonly ProjectDatabaseContext context;
        public PatientRepo(ProjectDatabaseContext _context) 
        { 
            context= _context;
        }

        public List<Patient> GetAllPatient()
        {
            var pa=(from p in context.Patients
                    where p.FirstName != null orderby p.FirstName
                    select p).ToList();
            return pa;
        }

        public Patient DeletePatient(string email)
        {
            var patient = context.Patients.Where(p=>p.Email == email).FirstOrDefault();
            context.Patients.Remove(patient);
            context.SaveChanges();
            return patient;
        }

        public Patient RegisterPatient(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
            return patient;
        }

        public Patient UpdatePatient(Patient patient)
        {
            context.Patients.Update(patient);
            context.SaveChanges();
            return patient;
        }

        public Patient GetPatient(Guid Id)
        {
            var patient = (from p in context.Patients
                           where p.PatientId==Id
                           select p).FirstOrDefault();
            return patient;
        }

        public Patient GetPatientByEmail(string email)
        {
            var patients=GetAllPatient();
            var result=patients.FirstOrDefault(p=>p.Email==email);
            return result;
        }
    }
}
