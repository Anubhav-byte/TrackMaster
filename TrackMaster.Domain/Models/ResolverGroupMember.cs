using System;
using System.Collections.Generic;

namespace TrackMaster.Domain.Models;

public partial class ResolverGroupMember
{
    public int Id { get; set; }

    public int ResolverGroupId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ResolverGroup ResolverGroup { get; set; } = null!;
}
