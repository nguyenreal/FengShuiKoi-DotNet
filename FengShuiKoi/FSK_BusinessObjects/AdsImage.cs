using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class AdsImage
{
    public string AdImageId { get; set; } = null!;

    public string? AdImageUrl { get; set; }

    public string? AdId { get; set; }

    public virtual Advertisement? Ad { get; set; }
}
