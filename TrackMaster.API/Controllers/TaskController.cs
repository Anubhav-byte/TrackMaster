using Microsoft.AspNetCore.Mvc;
using TrackMaster.Domain.Models;
using TrackMaster.Domain.ResolverGroups;
using TrackMaster.Domain.Tasks;
using Task = TrackMaster.Domain.Tasks.Task;
using TaskDbModel = TrackMaster.Domain.Models.Task;

namespace TrackMaster.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public TaskController(ITaskAttachmentRepository taskAttachmentRepository,ITaskStatusRepository taskStatusRepository,IResolverGroupRepository resolverGroupRepository,ITaskRepository taskRepository)
        {
            TaskAttachmentRepository = taskAttachmentRepository;
            TaskStatusRepository = taskStatusRepository;
            ResolverGroupRepository = resolverGroupRepository;
            TaskRepository = taskRepository;
        }

        private ITaskAttachmentRepository TaskAttachmentRepository { get; }
        private ITaskStatusRepository TaskStatusRepository { get; }
        private IResolverGroupRepository ResolverGroupRepository { get; }
        private ITaskRepository TaskRepository { get; }

        [HttpPost]
        public async Task<IActionResult> AddTask(Task task)
        {

            TaskDbModel taskDbModel = new TaskDbModel()
            {
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                ResolverGroupId = task.ResolverGroupId,
                Status = await TaskStatusRepository.GetStatus(task.Status),
                StatusReasonCode = task.StatusReasonCode,
                AttachmentId =task.AttachmentId,
                CreatedBy = task.CreatedBy,
                AssignedTo = task.AssignedTo,
                DueDate = task.DueDate

            };

            var response = await TaskRepository.AddTask(taskDbModel);

            if(response == null)
            {
                return StatusCode(500, "Internal Server Error");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskStatus(string status)
        {
            var response = await TaskStatusRepository.AddStatus(status);

            if(response == null)
            {
                return StatusCode(500);
            }
            return Ok(response);
        }
    }
}
