using System;
using System.Collections.Generic;

namespace E_COMMERCE.Models;

public partial class Review
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }
}
