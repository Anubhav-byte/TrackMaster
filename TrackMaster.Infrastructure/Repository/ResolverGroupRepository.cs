using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMaster.Domain.Employees;
using TrackMaster.Domain.ResolverGroups;
using TrackMaster.Domain.Models;
using TrackMaster.Domain.Persistence;
using TrackMaster.Domain.Repository._shared;
using ResolverGroup = TrackMaster.Domain.ResolverGroups.ResolverGroup;
using ResolverGroupDbModel = TrackMaster.Domain.Models.ResolverGroup;
using Employee = TrackMaster.Domain.Models.Employee;

namespace TrackMaster.Domain.Repository
{
    public class ResolverGroupRepository : BaseRepository, IResolverGroupRepository
    {
        IEmployee _employeeRepository;
        public ResolverGroupRepository(TrackMasterContext context,IEmployee employeeRepository) : base(context) {
            _employeeRepository = employeeRepository;
        }
        public async Task<ResolverGroup> AddResolverGroup(AddResolverGroupRequest resolverGroupRequest)
        {
            try
            {
                var response = _dbContext.Add(entity: new ResolverGroupDbModel() { ResolverGroupName = resolverGroupRequest.ResolverGroupName });

                if(response.State.ToString() == "Added")
                {
                   _dbContext.SaveChanges();
                }

                return new ResolverGroup() { ResolverGroupId = response.Entity.ResolverGroupId, ResolverGroupName = response.Entity.ResolverGroupName };
            }
            catch (Exception e)
            {
                return null;
                //throw;
            }
            
        }

        public async Task<ResolverGroupMember> AddResolverGroupMember(AddResolveGroupMember addResolveGroupMember)
        {
            try
            {
                
                var resolverGroup = await GetResolverGroup(-1, addResolveGroupMember.ResolverGroupName);
                Employee employee = await _employeeRepository.GetEmployee(addResolveGroupMember.EmployeeId);
                if(resolverGroup != null)
                {
                    ResolverGroupMember resolverGroupMember = new ResolverGroupMember()
                    {
                        EmployeeId = addResolveGroupMember.EmployeeId,
                        ResolverGroupId = resolverGroup.ResolverGroupId,
                        ResolverGroup = resolverGroup
                    };
                    var response = _dbContext.ResolverGroupMembers.Add(resolverGroupMember);
                    if (response.State.ToString() == "Added")
                    {
                        _dbContext.SaveChanges();
                        return response.Entity;
                    }


                    
                }
                return null;

            }
                
            catch (Exception ex)
            {
                return null;
                //throw;
            }
            
        }

        public async Task<ResolverGroupDbModel> GetResolverGroup(int resolverGroupId , string resolverGroupName = null)
        {
            try
            {
                if (resolverGroupId != -1)
                {

                    ResolverGroupDbModel resolverGroup = _dbContext.ResolverGroups.Where(x => x.ResolverGroupId == resolverGroupId).FirstOrDefault();
                    return resolverGroup;
                }
                else
                {
                    if (resolverGroupName != null)
                    {

                        ResolverGroupDbModel resolverGroup = _dbContext.ResolverGroups.Where(x => x.ResolverGroupName == resolverGroupName).FirstOrDefault();
                        return resolverGroup;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                //throw;
            }
            

            return null;
        }
    }
}
