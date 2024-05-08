using System;
using System.Collections.Generic;

namespace AspNetCoreMVC_ODEV2.Models;

public partial class Room
{
    public int Id { get; set; }

    public int RoomNumber { get; set; }

    public int BuildingNumber { get; set; }

    public int FloorNumber { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Doctor IdNavigation { get; set; } = null!;
}
