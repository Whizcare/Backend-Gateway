using DataEntities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Logic
{
    public class PatientLogic : IPatientLogic
    {
        private readonly IPatient p;
        public PatientLogic(IPatient _p) 
        { 
            p= _p;
        }
        public Patient AddPatient(Patient patient)
        {
            return Mapper.Map(p.RegisterPatient(Mapper.Map(patient)));
        }

        public Patient DeletePatient(string email)
        {
            var pat=p.DeletePatient(email);
            return Mapper.Map(pat);
        }

        public Patient GetPatientByEmail(string email)
        {
            return Mapper.Map(p.GetPatientByEmail(email));
        }

        public Patient GetPatientById(Guid id)
        {
            var pa=(from pat in p.GetAllPatient()
                    where pat.PatientId==id
                    select pat).FirstOrDefault();
            if(pa!=null)
            {
                return Mapper.Map(pa);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Patient> GetPatients()
        {
            return Mapper.Map(p.GetAllPatient());
        }

        public Patient LoginPatient(string email, string password)
        {
            var pati=(from pa in p.GetAllPatient()
                      where pa.Email == email && pa.Password == password
                      select pa).FirstOrDefault();
            if(pati!= null)
            {
                return Mapper.Map(pati);
            }
            else
            {
                return null;
            }
        }

        public Patient UpdatePatient(string email, Patient patient)
        {
            var P=(from pa in p.GetAllPatient()
                   where pa.Email==email
                   select pa).FirstOrDefault();

            if(P!= null)
            {
                P.FirstName= patient.FirstName;
                P.LastName= patient.LastName;
                P.Password= patient.Password;
                P.Phone= patient.Phone;
                P.Gender= patient.Gender;
                P.DateOfBirth= patient.DateOfBirth;
                P.City= patient.City;
                P.State= patient.State;
                P.Zipcode= patient.Zipcode;
                P.BloodGroup= patient.BloodGroup;

                P=p.UpdatePatient(P);
            }
            return Mapper.Map(P);
        }
    }
}
