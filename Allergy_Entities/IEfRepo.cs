using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ED = DataEntities.Entities;

namespace DataEntities
{
    public interface IEfRepo
    {
        public List<ED.Allergy> GetAllAllergies(Guid appointmentid);
        public ED.Allergy addPatientAllergy(ED.Allergy allergy);
    }
}


