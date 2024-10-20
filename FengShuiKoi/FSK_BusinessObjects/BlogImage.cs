using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class BlogImage
{
    public string BlogImageId { get; set; } = null!;

    public string? BlogImageUrl { get; set; }

    public string? BlogId { get; set; }
}
