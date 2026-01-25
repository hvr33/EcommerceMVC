using System;
using System.Collections.Generic;

namespace E_COMMERCE.Models;

public partial class Orderdetial
{
    internal int? UnitPrice;

    public int Id { get; set; }

    public int? Productid { get; set; }

    public decimal? Totalprice { get; set; }

    public int? Quantity { get; set; }

    public int? Orderid { get; set; }

    public decimal? Price { get; set; }

    public DateOnly? Entitydata { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
