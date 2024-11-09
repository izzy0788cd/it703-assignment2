using System;
using System.Collections.Generic;

namespace HotelWebApp.Models;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public int MaxOccupants { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
