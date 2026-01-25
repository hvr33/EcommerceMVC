using System;
using System.Collections.Generic;

namespace E_COMMERCE.Models;

public partial class AuditLog
{
    public int Id { get; set; }

    public string ActivityType { get; set; } = null!;

    public string? Description { get; set; }

    public string? UserName { get; set; }

    public string? UserId { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public string? LogLevel { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual AspNetUser? User { get; set; }
}
