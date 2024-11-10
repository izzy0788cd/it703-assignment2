using System;
using System.Collections.Generic;

namespace HotelWebApp.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public int RoomTypeId { get; set; }

    public int StatusId { get; set; }

    public bool BookingAvailable { get; set; }

    public string? CarPark { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual RoomType RoomType { get; set; } = null!;

    public virtual RoomStatus Status { get; set; } = null!;
}
