using Entity=DataEntities.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IDoctorLogic
    {
        public List<Models.Doctor> GetAllDoctors();
        public Models.Doctor GetDoctorByEmail(string Email);
        public List<Models.Doctor> GetDoctorByDepartment(string Department);
        public List<Models.Doctor> GetAllDoctorsByAvailability(string Day);
        public Models.Doctor AddDoctor(Models.Doctor Doctor);
    }
}
