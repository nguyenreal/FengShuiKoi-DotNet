using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class Advertisement
{
    public string AdId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public double? Price { get; set; }

    public int? ElementId { get; set; }

    public string? CategoryId { get; set; }

    public string? UserId { get; set; }

    public string? AdImageId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<AdsImage> AdsImages { get; set; } = new List<AdsImage>();

    public virtual Category? Category { get; set; }

    public virtual Element? Element { get; set; }

    public virtual User? User { get; set; }
}
