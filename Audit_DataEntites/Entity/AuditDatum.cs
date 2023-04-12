using System;
using System.Collections.Generic;

namespace Audit_DataEntites.Entity;

public partial class AuditDatum
{
    public Guid Id { get; set; }

    public string? PatientEmail { get; set; }

    public string? PatientnameFirstName { get; set; }

    public string? PatientnameLastName { get; set; }

    public string? Date { get; set; }

    public string? DoctorName { get; set; }

    public string? Dignosis { get; set; }

    public int? Height { get; set; }

    public int? Weight { get; set; }

    public int? Temperature { get; set; }

    public int? Spo2 { get; set; }

    public string? BloodPressure { get; set; }

    public int? SugarLevel { get; set; }

    public string? AdditioanlDetails { get; set; }

    public string? Allergies { get; set; }
}
