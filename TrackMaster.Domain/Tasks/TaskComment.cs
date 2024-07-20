using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMaster.Domain.Shared;

namespace TrackMaster.Domain.Tasks
{
    public class TaskComment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        [ForeignKey("TaskId")]
        public Task Task { get; set; }
        public string Comment { get; set; }

        [ForeignKey("AttachmentId")]
        public TaskAttachment TaskAttachment { get; set; }
    }
}
