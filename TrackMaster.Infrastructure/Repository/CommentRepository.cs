using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMaster.Domain.Models;
using TrackMaster.Domain.Persistence;
using TrackMaster.Domain.Repository._shared;
using TrackMaster.Domain.Tasks;
using TaskAttachment = TrackMaster.Domain.Models.TaskAttachment;
using TaskComment = TrackMaster.Domain.Models.TaskComment;

namespace TrackMaster.Infrastructure.Repository
{
    public class CommentRepository : BaseRepository, ITaskCommentRepository
    {
        public CommentRepository(TrackMasterContext trackMasterContext) : base(trackMasterContext)
        {
        }

        public async Task<TaskComment> AddComment(string comment, int taskId, int attachmentId)
        {
            try
            {
                TaskComment commentTask = new TaskComment()
                {
                    Comment = comment,
                    TaskId = taskId,
                    AttachmentId = attachmentId,
                };

                var dbResponse = _dbContext.TaskComments.Add(commentTask);
                if(dbResponse.State.ToString() == "Added")
                {
                    await _dbContext.SaveChangesAsync();
                    return dbResponse.Entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
                
            }
        }

        public Task<Domain.Tasks.TaskAttachment> GetTaskAttachment(int attachmentId)
        {
            throw new NotImplementedException();
        }
    }
}
