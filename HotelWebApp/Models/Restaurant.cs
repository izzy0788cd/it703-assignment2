using System;
using System.Collections.Generic;

namespace HotelWebApp.Models;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    public string RestaurantName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string PostCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int Fee { get; set; }

    public int? BookingId { get; set; }

    public virtual Booking? Booking { get; set; }
}
