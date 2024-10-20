using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class KoiFish
{
    public string KoiId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Size { get; set; }

    public string? Weight { get; set; }

    public string? Color { get; set; }

    public string? Description { get; set; }

    public string? KoiTypeId { get; set; }

    public virtual ICollection<KoiImage> KoiImages { get; set; } = new List<KoiImage>();

    public virtual KoiType? KoiType { get; set; }

    public virtual ICollection<Element> Elements { get; set; } = new List<Element>();
}
