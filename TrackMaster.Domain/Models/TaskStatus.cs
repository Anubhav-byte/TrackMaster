using System;
using System.Collections.Generic;

namespace TrackMaster.Domain.Models;

public partial class TaskStatus
{
    public int StatusId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
