using System;
using System.Collections.Generic;

namespace AspNetCoreMVC_ODEV2.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
