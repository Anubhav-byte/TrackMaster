using System;
using System.Collections.Generic;

namespace TrackMaster.Domain.Models;

public partial class TaskComment
{
    public int CommentId { get; set; }

    public int TaskId { get; set; }

    public string Comment { get; set; } = null!;

    public int AttachmentId { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public virtual TaskAttachment Attachment { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
