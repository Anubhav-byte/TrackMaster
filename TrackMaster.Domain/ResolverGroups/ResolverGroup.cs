using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackMaster.Domain.Shared;

namespace TrackMaster.Domain.ResolverGroups
{
    public class ResolverGroup : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResolverGroupId { get; set; }
        public string ResolverGroupName { get; set; }
    }

    public record AddResolverGroupRequest
    {
        public string ResolverGroupName { get; set; }
    }

    public record AddResolveGroupMember
    {
        public string ResolverGroupName { get; set; }
        public int EmployeeId { get; set; }
    }
}
