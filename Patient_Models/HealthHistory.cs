namespace Models
{
    public class HealthHistory
    {
        public Guid HhId { get; set; }

        public Guid? PatientId { get; set; }

        public DateTime Date { get; set; }

        public string? DoctorName { get; set; }

        public string? Diagnosis { get; set; }
        public Guid? AppointmentId { get; set; }

    }
}