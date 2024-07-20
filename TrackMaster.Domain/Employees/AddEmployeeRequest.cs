using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMaster.Domain.Employees
{
    public record AddEmployeeRequest
    {
        public int ManagerId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail {  get; set; }
        public bool IsAdmin { get; set; }
    }
}
