using System;
using System.Collections.Generic;

namespace E_COMMERCE.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
