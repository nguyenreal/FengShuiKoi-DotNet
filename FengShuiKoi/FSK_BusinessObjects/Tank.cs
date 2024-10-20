using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class Tank
{
    public string TankId { get; set; } = null!;

    public string? Shape { get; set; }

    public string? ImageUrl { get; set; }

    public int? ElementId { get; set; }

    public virtual Element? Element { get; set; }
}
