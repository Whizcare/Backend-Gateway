using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntities;
using Models;

namespace BusinessLogic
{
    public class logic : Ilogic
    {
        private readonly IEfRepo repo;
        public logic(IEfRepo _repo)
        {
            repo = _repo;
        }
        public Allergy addPatientAllergy(Allergy allergy)
        {
           return Mapper.AllergyMapper(repo.addPatientAllergy(Mapper.AllergyMapper(allergy)));
        }

        public List<Allergy> GetAllAllergies(Guid appointmentid)
        {
            return Mapper.AllergyMapper(repo.GetAllAllergies(appointmentid));
        }
    }
}
