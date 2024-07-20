using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMaster.Domain.Employees;
using TrackMaster.Domain.Shared;

namespace TrackMaster.Domain.ResolverGroups
{
    public class ResolverGroupMembers : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [ForeignKey("ResolverGroupId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ResolverGroup ResolverGroup { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
