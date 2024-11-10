using System;
using System.Collections.Generic;

namespace HotelWebApp.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int CustomerId { get; set; }

    public int RoomId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public int NumberOfGuests { get; set; }

    public decimal Price { get; set; }

    public int CreditCardId { get; set; }

    public bool DepositMade { get; set; }

    public string? DepositMethod { get; set; }

    public string DepositStatus { get; set; } = null!;

    public string? BookingReference { get; set; }

    public virtual CreditCard CreditCard { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

    public virtual Room Room { get; set; } = null!;
}
