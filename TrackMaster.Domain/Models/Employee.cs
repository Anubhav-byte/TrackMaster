using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrackMaster.Domain.Models;

public partial class Employee
{
    public HierarchyId OrgNode { get; set; } = null!;

    public short? OrgLevel { get; set; }

    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string EmployeeEmail { get; set; } = null!;

    public bool? IsAdmin { get; set; }

    public virtual ICollection<ResolverGroupMember> ResolverGroupMembers { get; set; } = new List<ResolverGroupMember>();

    public virtual ICollection<Task> TaskAssignedToNavigations { get; set; } = new List<Task>();

    public virtual ICollection<Task> TaskCreatedByNavigations { get; set; } = new List<Task>();
}
