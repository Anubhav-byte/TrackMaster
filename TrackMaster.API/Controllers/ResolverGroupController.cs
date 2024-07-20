using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackMaster.Domain.ResolverGroups;
using TrackMaster.Domain.Repository;

namespace TrackMaster.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResolverGroupController : ControllerBase
    {
        IResolverGroupRepository _resolverGroupRepository;
        public ResolverGroupController(IResolverGroupRepository resolverGroupRepository) {
            _resolverGroupRepository = resolverGroupRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddResolverGroup(AddResolverGroupRequest addResolverGroupRequest)
        {
            var response = _resolverGroupRepository.AddResolverGroup(addResolverGroupRequest);

            if(response == null)
            {
                return StatusCode(500, "Internal Server Error");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddResolverGroupMember(AddResolveGroupMember addResolveGroupMember)
        {
            var resolver = _resolverGroupRepository.AddResolverGroupMember(addResolveGroupMember);
            return Ok();
        }
    }
}
