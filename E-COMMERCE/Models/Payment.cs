using System;
using System.Collections.Generic;

namespace E_COMMERCE.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string Provider { get; set; } = null!;

    public string? ProviderPaymentId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? RawResponse { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Order Order { get; set; } = null!;
}
