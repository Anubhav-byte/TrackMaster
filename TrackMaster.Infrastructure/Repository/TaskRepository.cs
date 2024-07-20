using Microsoft.EntityFrameworkCore;
using TrackMaster.Domain.Persistence;
using TrackMaster.Domain.Repository._shared;
using TrackMaster.Domain.Tasks;

namespace TrackMaster.Infrastructure.Repository
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        private ITaskStatusRepository _taskStatusRepository { get; set; }
        public TaskRepository(TrackMasterContext trackMasterContext,ITaskStatusRepository taskStatusRepository) : base(trackMasterContext)
        {
            _taskStatusRepository = taskStatusRepository;
        }

        public async Task<Domain.Models.Task> AddTask(Domain.Models.Task task)
        {
            try
            {
                var response = await _dbContext.Tasks.AddAsync(task);
                if (response.State.ToString() == "Added")
                {
                    _dbContext.SaveChanges();
                    return response.Entity;
                }
                return null;
                
            }
            catch (Exception ex)
            {
                return null;
                //throw;
            }
        }

        public async Task<Domain.Models.Task> GetTask(int taskId)
        {
            try
            {
                var dbResponse = await _dbContext.Tasks.Where(t => t.TaskId == taskId).FirstOrDefaultAsync();
                return dbResponse;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public async Task<List<Domain.Models.Task>> GetTaskByEmployeeId(int employeeId,int statusid)
        {
            try
            {
                var dbResponse = await _dbContext.Tasks.Where(t => t.AssignedTo == employeeId && t.StatusId==statusid).ToListAsync();
                return dbResponse;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public async Task<Domain.Models.Task> ChangeTaskStatus(int taskId,string status)
        {
            try
            {
                var task = await _dbContext.Tasks.Where(t => t.TaskId == taskId).FirstOrDefaultAsync();
                var taskStatus = await _taskStatusRepository.GetStatus(status);

                if (task != null)
                {
                    task.StatusId = taskStatus.StatusId;
                    _dbContext.SaveChangesAsync();
                    return task;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
                //throw;
            }
        } 
    }
}
