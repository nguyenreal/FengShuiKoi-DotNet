using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class Category
{
    public string CategoryId { get; set; } = null!;

    public string? CategoryName { get; set; }

    public virtual ICollection<Advertisement> Advertisements { get; set; } = new List<Advertisement>();
}
