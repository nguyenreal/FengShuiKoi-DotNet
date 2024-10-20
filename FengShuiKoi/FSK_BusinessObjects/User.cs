using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Email { get; set; }

    public string? ImageUrl { get; set; }

    public string? RoleName { get; set; }

    public string? PlanId { get; set; }

    public int? ElementId { get; set; }

    public bool? DeleteStatus { get; set; }

    public virtual ICollection<Advertisement> Advertisements { get; set; } = new List<Advertisement>();

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Element? Element { get; set; }

    public virtual PricingPlan? Plan { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
