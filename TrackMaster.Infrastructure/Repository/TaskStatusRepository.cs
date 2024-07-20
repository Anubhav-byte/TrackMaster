using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMaster.Domain.Models;
using TrackMaster.Domain.Persistence;
using TrackMaster.Domain.Repository._shared;
using TrackMaster.Domain.Tasks;

namespace TrackMaster.Infrastructure.Repository
{
    public class TaskStatusRepository : BaseRepository, ITaskStatusRepository
    {
        public TaskStatusRepository(TrackMasterContext trackMasterContext) : base(trackMasterContext)
        {
        }

        public async Task<Domain.Models.TaskStatus> AddStatus(string status)
        {
            try
            {
                var dbResponse = await _dbContext.TaskStatuses.AddAsync(new Domain.Models.TaskStatus() { Status = status });
                if(dbResponse.State.ToString() == "Added")
                {
                    _dbContext.SaveChanges();
                    return dbResponse.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Task<List<Domain.Models.TaskStatus>> GetAllStatus()
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Models.TaskStatus> GetStatus(string status)
        {
            try
            {
                Domain.Models.TaskStatus taskStatus = _dbContext.TaskStatuses.Where(x=> x.Status == status).FirstOrDefault();

                return taskStatus;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }


    }
}
