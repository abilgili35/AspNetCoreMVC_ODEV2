using System;
using System.Collections.Generic;

namespace AspNetCoreMVC_ODEV2.Models;

public partial class PatientInfo
{
    public int Id { get; set; }

    public DateTime BirthDate { get; set; }

    public double Height { get; set; }

    public double Weight { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Patient IdNavigation { get; set; } = null!;
}
