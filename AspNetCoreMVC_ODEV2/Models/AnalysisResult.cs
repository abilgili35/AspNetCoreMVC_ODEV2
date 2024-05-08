using System;
using System.Collections.Generic;

namespace AspNetCoreMVC_ODEV2.Models;

public partial class AnalysisResult
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public DateTime AnalysisDate { get; set; }

    public string FileLink { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
