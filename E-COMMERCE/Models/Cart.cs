using System;
using System.Collections.Generic;

namespace E_COMMERCE.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int? Productid { get; set; }

    public string? Userid { get; set; }

    public string? Photo { get; set; }

    public decimal? Price { get; set; }

    public int? Quntity { get; set; }

    public virtual Product? Product { get; set; }
}
