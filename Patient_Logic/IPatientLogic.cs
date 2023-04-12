using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Logic
{
    public interface IPatientLogic
    {
        Patient AddPatient(Patient patient);
        Patient UpdatePatient(string email,Patient patient);
        Patient DeletePatient(string email);
        Patient LoginPatient(string email,string password);
        IEnumerable<Patient> GetPatients();
        Patient GetPatientById(Guid id);
         public Models.Patient GetPatientByEmail(string email);
      
    }
}
