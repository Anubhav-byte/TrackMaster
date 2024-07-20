using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TrackMaster.Domain.Employees;

public class Employee
{

    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string EmployeeEmail { get; set; } = null!;

    public bool? IsAdmin { get; set; }
}
