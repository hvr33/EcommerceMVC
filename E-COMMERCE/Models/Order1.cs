using System;
using System.Collections.Generic;

namespace E_COMMERCE.Models;

public partial class Order1
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string name { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public int CountryId { get; set; }

    public int StateId { get; set; }

    public int CityId { get; set; }

    public string Address { get; set; } = null!;

    public DateTime? OrderDate { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual State State { get; set; } = null!;
}
