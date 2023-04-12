using System;
using System.Collections.Generic;

namespace DataEntities.Entities;

public partial class Doctor
{
    public Guid DoctorId { get; set; }

    public string? DoctorName { get; set; }

    public string? Email { get; set; }

    public string? Qualification { get; set; }

    public string? Department { get; set; }

    public virtual ICollection<PhysicianAvailabilityStatus> PhysicianAvailabilityStatuses { get; } = new List<PhysicianAvailabilityStatus>();
}
