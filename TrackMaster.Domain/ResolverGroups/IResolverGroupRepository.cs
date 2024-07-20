using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMaster.Domain.Models;

namespace TrackMaster.Domain.ResolverGroups
{
    public interface IResolverGroupRepository
    {
        public Task<ResolverGroup> AddResolverGroup(AddResolverGroupRequest addResolverGroupRequest);
        public Task<ResolverGroupMember> AddResolverGroupMember(AddResolveGroupMember addResolveGroupMember);
        public Task<Models.ResolverGroup> GetResolverGroup(int resolverGroupId, string resolverGroupName = null);
    }
}
