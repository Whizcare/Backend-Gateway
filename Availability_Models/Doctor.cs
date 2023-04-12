namespace Models
{
    public class Doctor
    {
        public Guid DoctorId { get; set; }

        public string? DoctorName { get; set; }

        public string? Email { get; set; }

        public string? Qualification { get; set; }

        public string? Department { get; set; }
    }
}