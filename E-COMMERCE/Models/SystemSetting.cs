using System;
using System.Collections.Generic;

namespace E_COMMERCE.Models;

public partial class SystemSetting
{
    public int Id { get; set; }

    public string SettingKey { get; set; } = null!;

    public string? SettingValue { get; set; }

    public string? Description { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
