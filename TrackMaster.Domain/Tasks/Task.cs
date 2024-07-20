using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackMaster.Domain.Employees;
using TrackMaster.Domain.ResolverGroups;
using TrackMaster.Domain.Shared;

namespace TrackMaster.Domain.Tasks
{
    public class Task : BaseEntity
    {
        private ResolverGroup resolverGroupId;

        [Required]
        public string TaskName { get; set; }
        [Required]
        public string TaskDescription { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string StatusReasonCode { get; set; }
        public int AttachmentId { get; set; }
        [Required]
        public int AssignedTo { get; set; }

        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int ResolverGroupId { get; set; }
    }
}
