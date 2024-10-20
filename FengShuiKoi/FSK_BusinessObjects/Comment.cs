using System;
using System.Collections.Generic;

namespace FSK_BusinessObjects;

public partial class Comment
{
    public int CommentId { get; set; }

    public string? UserId { get; set; }

    public DateOnly CommentDate { get; set; }

    public string Content { get; set; } = null!;

    public string? BlogId { get; set; }

    public virtual Blog? Blog { get; set; }

    public virtual User? User { get; set; }
}
