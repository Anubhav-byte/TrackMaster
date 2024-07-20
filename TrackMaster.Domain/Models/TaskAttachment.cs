using System;
using System.Collections.Generic;

namespace TrackMaster.Domain.Models;

public partial class TaskAttachment
{
    public int AttachmentId { get; set; }

    public string AttachmentType { get; set; } = null!;

    public string AttchmentLocation { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
