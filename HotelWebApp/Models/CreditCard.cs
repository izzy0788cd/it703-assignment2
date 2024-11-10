using System;
using System.Collections.Generic;

namespace HotelWebApp.Models;

public partial class CreditCard
{
    public int CreditCardId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Number { get; set; } = null!;

    public DateOnly ExpirationDate { get; set; }

    public string SecurityCode { get; set; } = null!;

    public string BillingAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
