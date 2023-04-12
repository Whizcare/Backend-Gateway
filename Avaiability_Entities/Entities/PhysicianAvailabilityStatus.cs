using System;
using System.Collections.Generic;

namespace DataEntities.Entities;

public partial class PhysicianAvailabilityStatus
{
    public Guid AvailabilityId { get; set; }

    public Guid? DoctorId { get; set; }

    public bool? Sunday { get; set; }

    public bool? Monday { get; set; }

    public bool? Tuesday { get; set; }

    public bool? Wednesday { get; set; }

    public bool? Thursday { get; set; }

    public bool? Friday { get; set; }

    public bool? Saturday { get; set; }

    public virtual Doctor? Doctor { get; set; }
}
