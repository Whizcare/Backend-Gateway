using System;
using System.Collections.Generic;

namespace DataEntities.Entities;

public partial class HealthHistory
{
    public Guid HhId { get; set; }

    public Guid? PatientId { get; set; }

    public DateTime Date { get; set; }

    public string? DoctorName { get; set; }

    public string? Diagnosis { get; set; }

    public Guid? AppointmentId { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; } = new List<Prescription>();
}
