using System;
using System.Collections.Generic;

namespace AspNetCoreMVC_ODEV2.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int IdentityNumber { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<AnalysisResult> AnalysisResults { get; set; } = new List<AnalysisResult>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual PatientInfo? PatientInfo { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
