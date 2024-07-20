using System;
using System.Collections.Generic;

namespace TrackMaster.Domain.Models;

public partial class ResolverGroup
{
    public int ResolverGroupId { get; set; }

    public string ResolverGroupName { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public virtual ICollection<ResolverGroupMember> ResolverGroupMembers { get; set; } = new List<ResolverGroupMember>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
