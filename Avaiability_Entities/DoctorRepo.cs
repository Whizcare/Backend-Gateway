using DataEntities.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly DoctorDbContext context;
        public DoctorRepo(DoctorDbContext _context)
        {
            context = _context;
        }
        public Doctor AddDoctor(Doctor Doctor)
        {
            context.Doctors.Add(Doctor);
            context.SaveChanges();
            return Doctor;
        }

        public List<Doctor> GetAllDoctors()
        {
            var s = (from d in context.Doctors
                     where d.DoctorName != null
                     orderby d.DoctorName
                     select d).ToList();
            return s;
        }

        public List<Doctor> GetAllDoctorsByAvailability(string Day)
        {
            switch(Day)
            {
                case "Monday":
                    var Doc = from Doctor in context.Doctors
                              join physician in context.PhysicianAvailabilityStatuses
                              on Doctor.DoctorId equals physician.DoctorId
                              where physician.Monday == true
                              select Doctor;
                    return Doc.ToList();
                case "Tuesday":
                     Doc = from Doctor in context.Doctors
                              join physician in context.PhysicianAvailabilityStatuses
                              on Doctor.DoctorId equals physician.DoctorId
                              where physician.Tuesday == true
                              select Doctor;
                    return Doc.ToList();
                case "Wednesday":
                    Doc = from Doctor in context.Doctors
                              join physician in context.PhysicianAvailabilityStatuses
                              on Doctor.DoctorId equals physician.DoctorId
                              where physician.Wednesday == true
                              select Doctor;
                    return Doc.ToList();
                case "Thursday":
                     Doc = from Doctor in context.Doctors
                              join physician in context.PhysicianAvailabilityStatuses
                              on Doctor.DoctorId equals physician.DoctorId
                              where physician.Thursday == true
                              select Doctor;
                    return Doc.ToList();
                case "Friday":
                     Doc = from Doctor in context.Doctors
                              join physician in context.PhysicianAvailabilityStatuses
                              on Doctor.DoctorId equals physician.DoctorId
                              where physician.Friday == true
                              select Doctor;
                    return Doc.ToList();
                case "Saturday":
                    Doc = from Doctor in context.Doctors
                              join physician in context.PhysicianAvailabilityStatuses
                              on Doctor.DoctorId equals physician.DoctorId
                              where physician.Saturday == true
                              select Doctor;
                    return Doc.ToList();
                case "Sunday":
                     Doc = from Doctor in context.Doctors
                              join physician in context.PhysicianAvailabilityStatuses
                              on Doctor.DoctorId equals physician.DoctorId
                              where physician.Sunday == true
                              select Doctor;
                    return Doc.ToList();
                default: return Enumerable.Empty<Doctor>().ToList();
            }
        }
        
        public  List<Doctor> GetDoctorByDepartment(string Department)
        {
            var doctor = GetAllDoctors();
            var dept = doctor.Where(x=> x.Department == Department);
            return dept.ToList();
        }

        public Doctor GetDoctorByEmail(string Email)
        {
            var doctors=GetAllDoctors();
            var result=doctors.FirstOrDefault(x => x.Email == Email);
            return result;
        }
    }
}
