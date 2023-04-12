using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public interface Ilogic
    {
        public List<Allergy> GetAllAllergies(Guid appointmentid);
        public Allergy addPatientAllergy(Allergy allergy);
    }
}
