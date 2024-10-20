using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class Transaction
{
    public string SubscriptionId { get; set; } = null!;

    public string? SubscriptionName { get; set; }

    public string? UserId { get; set; }

    public virtual User? User { get; set; }
}
