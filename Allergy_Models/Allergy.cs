namespace Models
{
    public class Allergy
    {
        public Guid AllergyId { get; set; }

        public string? AllergyName { get; set; }

        public Guid? AppointmentId { get; set; }
    }
}