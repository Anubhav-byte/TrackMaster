using System;
using System.Collections.Generic;

namespace TrackMaster.Domain.Models;

public partial class Task
{
    public int TaskId { get; set; }


    public string TaskName { get; set; } = null!;

    public string TaskDescription { get; set; } = null!;

    public DateTime DueDate { get; set; }

    public int StatusId { get; set; }

    public string StatusReasonCode { get; set; } = null!;

    public int AttachmentId { get; set; }

    public int ResolverGroupId { get; set; }

    public int CreatedBy { get; set; }

    public int AssignedTo { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public virtual Employee AssignedToNavigation { get; set; } = null!;

    public virtual TaskAttachment Attachment { get; set; } = null!;

    public virtual Employee CreatedByNavigation { get; set; } = null!;

    public virtual ResolverGroup ResolverGroup { get; set; } = null!;

    public virtual TaskStatus Status { get; set; } = null!;

    public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();
}
