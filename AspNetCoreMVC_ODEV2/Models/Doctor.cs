using System;
using System.Collections.Generic;

namespace AspNetCoreMVC_ODEV2.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Profession { get; set; } = null!;

    public DateTime DegreeDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Room? Room { get; set; }
}
