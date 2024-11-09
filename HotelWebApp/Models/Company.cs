using System;
using System.Collections.Generic;

namespace HotelWebApp.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
