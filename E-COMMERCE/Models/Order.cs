using System;
using System.Collections.Generic;

namespace E_COMMERCE.Models;

public partial class Order
{
    public string? Userid { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool? Onlinepaid { get; set; }

    public DateOnly? EntityDate { get; set; }

    public string? CustomerName { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    public string? Address { get; set; }

    public DateTime? OrderDate { get; set; }

    public int Id { get; set; }

    public int? Productid { get; set; }

    public virtual City? City { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Orderdetial> Orderdetials { get; set; } = new List<Orderdetial>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual State? State { get; set; }
}
