using TE = DataEntities.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public interface IDoctorRepo
    {
        public List<TE.Doctor> GetAllDoctors();
        public TE.Doctor GetDoctorByEmail(string Email);
        public List<TE.Doctor> GetDoctorByDepartment(string Department);
        public List<TE.Doctor> GetAllDoctorsByAvailability(string Day);
        public TE.Doctor AddDoctor(TE.Doctor Doctor);

    }
}
