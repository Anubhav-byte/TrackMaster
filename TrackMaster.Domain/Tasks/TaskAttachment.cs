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
    public class TaskAttachment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttachmentId { get; set; }
        public string AttachmentType { get; set; }
        public string AttchmentLocation { get; set; }
    }
}
