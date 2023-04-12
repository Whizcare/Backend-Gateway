using System;
using System.Collections.Generic;

namespace DataEntities.Entities;

public partial class Allergy
{
    public Guid AllergyId { get; set; }

    public string? AllergyName { get; set; }

    public Guid? AppointmentId { get; set; }
}
