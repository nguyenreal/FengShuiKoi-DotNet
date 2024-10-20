using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class Blog
{
    public string BlogId { get; set; } = null!;

    public string? Title { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? UserId { get; set; }

    public string? BlogImageId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? User { get; set; }
}
