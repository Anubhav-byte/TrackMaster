using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TrackMaster.Domain.Models;

namespace TrackMaster.Domain.Tasks
{
    public interface ITaskRepository
    {
        public Task<Models.Task> AddTask(Models.Task task);

        public Task<Models.Task> GetTask(int taskId);
        Task<List<Domain.Models.Task>> GetTaskByEmployeeId(int employeeId,int statusid);
        public Task<Domain.Models.Task> ChangeTaskStatus(int taskId, string status);
    }

    public interface ITaskAttachmentRepository
    {
        public Task<Models.TaskAttachment> AddAttachment(string fullFilePath,string fileType);
    }

    public interface ITaskCommentRepository
    {
        public Task<Models.TaskComment> AddComment(string comment,int taskId,int attachmentId);

        public Task<TaskAttachment> GetTaskAttachment(int attachmentId);
    }

    public interface ITaskStatusRepository
    {
        public Task<Models.TaskStatus> GetStatus(string status);
        public Task<Models.TaskStatus> AddStatus(string status);
        public Task<List<Models.TaskStatus>> GetAllStatus();


    }
}
