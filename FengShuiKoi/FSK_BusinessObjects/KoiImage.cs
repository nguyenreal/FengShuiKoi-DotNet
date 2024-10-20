using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class KoiImage
{
    public string KoiImageId { get; set; } = null!;

    public string? KoiImageUrl { get; set; }

    public string? KoiId { get; set; }

    public virtual KoiFish? Koi { get; set; }
}
