using System;
using System.Collections.Generic;

namespace E_COMMERCE.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? Ceito { get; set; }

    public string? Photo { get; set; }

    public string? Type { get; set; }

    public string? Siplername { get; set; }

    public DateOnly? Entitydata { get; set; }

    public string? Reviewurl { get; set; }

    public string? Productquntity { get; set; }

    public double? Rating { get; set; }

    public int? ReviewCount { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Cetogery? CeitoNavigation { get; set; }

    public virtual ICollection<Orderdetial> Orderdetials { get; set; } = new List<Orderdetial>();

    public virtual ICollection<Productimage> Productimages { get; set; } = new List<Productimage>();

    public virtual ICollection<Review2> Review2s { get; set; } = new List<Review2>();
}
