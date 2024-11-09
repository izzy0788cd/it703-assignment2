using System;
using System.Collections.Generic;

namespace HotelWebApp.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Notes { get; set; }

    public int? CompanyId { get; set; }

    public int? AgencyId { get; set; }

    public string? BookingReference { get; set; }

    public virtual TravelAgency? Agency { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Company? Company { get; set; }
}
