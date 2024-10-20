using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class KoiType
{
    public string KoiTypeId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();
}
