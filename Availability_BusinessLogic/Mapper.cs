using Models;
using TE = DataEntities.Entities;

namespace BusinessLogic
{
    public static class Mapper
    {
        public static Doctor MapDoctor(TE.Doctor doctor)
        {
            return new Doctor()
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.DoctorName,
                Email = doctor.Email,
                Qualification = doctor.Qualification,
                Department = doctor.Department
            };
        }
        public static PhysicianAvailabilityStatus MapPhysicianAvailabilityStatus(TE.PhysicianAvailabilityStatus physicianAvailabilityStatus)
        {
            return new PhysicianAvailabilityStatus()
            {
                AvailabilityId = physicianAvailabilityStatus.AvailabilityId,
                DoctorId = physicianAvailabilityStatus.DoctorId,
                Sunday = physicianAvailabilityStatus.Sunday,
                Monday = physicianAvailabilityStatus.Monday,
                Tuesday = physicianAvailabilityStatus.Tuesday,
                Wednesday = physicianAvailabilityStatus.Wednesday,
                Thursday = physicianAvailabilityStatus.Thursday,
                Friday = physicianAvailabilityStatus.Friday,
                Saturday = physicianAvailabilityStatus.Saturday

            };
        }

        public static TE.Doctor mapDoctor(Doctor doctor)
        {
            return new TE.Doctor()
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.DoctorName,
                Email = doctor.Email,
                Qualification = doctor.Qualification,
                Department = doctor.Department
            };
        }

        public static TE.PhysicianAvailabilityStatus mapPhysicianAvailabilityStatus(PhysicianAvailabilityStatus physicianAvailabilityStatus)
        {
            return new TE.PhysicianAvailabilityStatus()
            {
                AvailabilityId = physicianAvailabilityStatus.AvailabilityId,
                DoctorId = physicianAvailabilityStatus.DoctorId,
                Sunday = physicianAvailabilityStatus.Sunday,
                Monday = physicianAvailabilityStatus.Monday,
                Tuesday = physicianAvailabilityStatus.Tuesday,
                Wednesday = physicianAvailabilityStatus.Wednesday,
                Thursday = physicianAvailabilityStatus.Thursday,
                Friday = physicianAvailabilityStatus.Friday,
                Saturday = physicianAvailabilityStatus.Saturday
            };
        }

        public static List<Doctor> MapDoctor(List<TE.Doctor> doctors) 
        {
            return doctors.Select(MapDoctor).ToList();
        }
    }
}