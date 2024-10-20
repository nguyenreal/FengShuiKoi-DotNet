using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class Element
{
    public int ElementId { get; set; }

    public string ElementName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Quantity { get; set; }

    public string? Direction { get; set; }

    public int? Value { get; set; }

    public string? Color { get; set; }

    public string? Generation { get; set; }

    public string? Inhibition { get; set; }

    public virtual ICollection<Advertisement> Advertisements { get; set; } = new List<Advertisement>();

    public virtual ICollection<Tank> Tanks { get; set; } = new List<Tank>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<KoiFish> Kois { get; set; } = new List<KoiFish>();
}
