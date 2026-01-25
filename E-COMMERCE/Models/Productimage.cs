using System;
using System.Collections.Generic;

namespace E_COMMERCE.Models;

public partial class Productimage
{
    public int Id { get; set; }

    public int? Productid { get; set; }

    public string? Image { get; set; }

    public virtual Product? Product { get; set; }
}
