using System;
using System.Collections.Generic;

namespace DataEntities.Entities;

public partial class Prescription
{
    public Guid PrescriptionId { get; set; }

    public Guid? HhId { get; set; }

    public string? MedicineName { get; set; }

    public string? Dosage { get; set; }

    public string? Note { get; set; }

    public virtual HealthHistory? Hh { get; set; }
}
