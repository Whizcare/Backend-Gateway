using System;
using System.Collections.Generic;

namespace DataEntities.Entities;

public partial class Patient
{
    public Guid PatientId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zipcode { get; set; }

    public string? BloodGroup { get; set; }

    public virtual ICollection<HealthHistory> HealthHistories { get; } = new List<HealthHistory>();
}
