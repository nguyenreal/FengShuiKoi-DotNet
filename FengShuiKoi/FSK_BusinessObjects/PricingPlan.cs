using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class PricingPlan
{
    public string PlanId { get; set; } = null!;

    public string PlanName { get; set; } = null!;

    public string? Description { get; set; }

    public double? Price { get; set; }

    public DateOnly? RealTime { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
